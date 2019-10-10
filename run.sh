#!/bin/bash
set -e

echo This script creates several azure resources.

location=australiasoutheast
rg=testrg
kv=kvnameksdn
account=changeme # change this name 
database=database

az group create -n $rg -l $location

me=$(az ad signed-in-user show --query objectId -o tsv)
az keyvault create --location $location --name $kv --resource-group $rg
az keyvault set-policy --name $kv --object-id $me --secret-permissions get list
kvUri=$(az keyvault show --name $kv --query properties.vaultUri -o tsv)

az cosmosdb create -n $account -g $rg
az cosmosdb database create --name $account --resource-group $rg --db-name $database || true
key=$(az cosmosdb keys list --name $account --resource-group $rg --query primaryMasterKey -o tsv)

docker build -t test .

docker run -v ~/.azure:/.azure -e Name=$account -e PrimaryKey=$key -e KeyvaultUri=$kvUri -e AZURE_CONFIG_DIR=/.azure/ test

echo Delete the resource group with: az group delete -n $rg
