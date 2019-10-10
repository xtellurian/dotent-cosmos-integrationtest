#!/bin/bash
set -e

echo This script creates several azure resources.

location=australiasoutheast
rg=testrg
account=changeme # change this name 
database=database

az group create -n $rg -l $location

az cosmosdb create -n $account -g $rg
az cosmosdb database create --name $account --resource-group $rg --db-name $database || true
key=$(az cosmosdb keys list --name $account --resource-group $rg --query primaryMasterKey -o tsv)

docker build -t test .

docker run -it -v ~/.azure:/.azure -e Name=$account -e PrimaryKey=$key -e AZURE_CONFIG_DIR=/.azure/ test

echo Delete the resource group with: az group delete -n $rg
