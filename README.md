# dotent-cosmos-integrationtest

This repo reproduces a failure. Use `run.sh` to run the experiment

## Requirements:

* An Azure Account
* The Azure CLI
* UNIX shell
* docker

## Process

`run.sh` builds a simple Asp Net Core application w/ CosmosDB, EF Core and Azure Keyvault dependencies. Running the tests causes the following exception to be thrown, ending the tests early. The exception is not deterministic - it may not aways throw.

```
The active test run was aborted. Reason: Test host process crashed : Process terminated. Assertion failed.
   at Microsoft.Azure.Documents.Rntbd.Dispatcher.CallInfo..ctor(Guid activityId, Uri uri, TaskScheduler scheduler)
   at Microsoft.Azure.Documents.Rntbd.Dispatcher.CallAsync(ChannelCallArguments args)
   at System.Runtime.CompilerServices.AsyncMethodBuilderCore.Start[TStateMachine](TStateMachine& stateMachine)
   at Microsoft.Azure.Documents.Rntbd.Dispatcher.CallAsync(ChannelCallArguments args)
   at Microsoft.Azure.Documents.Rntbd.Channel.RequestAsync(DocumentServiceRequest request, Uri physicalAddress, ResourceOperation resourceOperation, Guid activityId)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecutionContextCallback(Object s)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext(Thread threadPoolThread)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext()
   at System.Threading.Tasks.AwaitTaskContinuation.RunOrScheduleAction(IAsyncStateMachineBox box, Boolean allowInlining)
   at System.Threading.Tasks.Task.RunContinuations(Object continuationObject)
   at System.Threading.Tasks.Task`1.TrySetResult(TResult result)
   at System.Threading.Tasks.UnwrapPromise`1.TrySetFromTask(Task task, Boolean lookForOce)
   at System.Threading.Tasks.UnwrapPromise`1.InvokeCore(Task completingTask)
   at System.Threading.Tasks.UnwrapPromise`1.Invoke(Task completingTask)
   at System.Threading.Tasks.Task.RunOrQueueCompletionAction(ITaskCompletionAction completionAction, Boolean allowInlining)
   at System.Threading.Tasks.Task.RunContinuations(Object continuationObject)
   at System.Threading.Tasks.Task`1.TrySetResult(TResult result)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder.SetResult()
   at Microsoft.Azure.Documents.Rntbd.Channel.<Initialize>b__12_0()
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecutionContextCallback(Object s)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext(Thread threadPoolThread)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext()
   at System.Threading.Tasks.AwaitTaskContinuation.RunOrScheduleAction(IAsyncStateMachineBox box, Boolean allowInlining)
   at System.Threading.Tasks.Task.RunContinuations(Object continuationObject)
   at System.Threading.Tasks.Task`1.TrySetResult(TResult result)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder.SetResult()
   at Microsoft.Azure.Documents.Rntbd.Channel.InitializeAsync()
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecutionContextCallback(Object s)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext(Thread threadPoolThread)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext()
   at System.Threading.Tasks.AwaitTaskContinuation.RunOrScheduleAction(IAsyncStateMachineBox box, Boolean allowInlining)
   at System.Threading.Tasks.Task.RunContinuations(Object continuationObject)
   at System.Threading.Tasks.Task`1.TrySetResult(TResult result)
   at System.Threading.Tasks.TaskFactory.CompleteOnInvokePromise.Invoke(Task completingTask)
   at System.Threading.Tasks.Task.RunOrQueueCompletionAction(ITaskCompletionAction completionAction, Boolean allowInlining)
   at System.Threading.Tasks.Task.RunContinuations(Object continuationObject)
   at System.Threading.Tasks.Task`1.TrySetResult(TResult result)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder.SetResult()
   at Microsoft.Azure.Documents.Rntbd.Dispatcher.OpenAsync(ChannelOpenArguments args)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecutionContextCallback(Object s)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext(Thread threadPoolThread)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext()
   at System.Threading.Tasks.AwaitTaskContinuation.RunOrScheduleAction(IAsyncStateMachineBox box, Boolean allowInlining)
   at System.Threading.Tasks.Task.RunContinuations(Object continuationObject)
   at System.Threading.Tasks.Task`1.TrySetResult(TResult result)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder.SetResult()
   at Microsoft.Azure.Documents.Rntbd.Dispatcher.NegotiateRntbdContextAsync(ChannelOpenArguments args)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecutionContextCallback(Object s)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext(Thread threadPoolThread)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext()
   at System.Threading.Tasks.AwaitTaskContinuation.RunOrScheduleAction(IAsyncStateMachineBox box, Boolean allowInlining)
   at System.Threading.Tasks.Task.RunContinuations(Object continuationObject)
   at System.Threading.Tasks.Task`1.TrySetResult(TResult result)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.SetExistingTaskResult(TResult result)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.SetResult(TResult result)
   at Microsoft.Azure.Documents.Rntbd.Connection.ReadResponseMetadataAsync(ChannelCommonArguments args)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecutionContextCallback(Object s)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext(Thread threadPoolThread)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext()
   at System.Threading.Tasks.AwaitTaskContinuation.RunOrScheduleAction(IAsyncStateMachineBox box, Boolean allowInlining)
   at System.Threading.Tasks.Task.RunContinuations(Object continuationObject)
   at System.Threading.Tasks.Task`1.TrySetResult(TResult result)
   at Microsoft.Azure.Documents.Rntbd.Connection.ReadPayloadAsync(Int32 length, String type, ChannelCommonArguments args)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecutionContextCallback(Object s)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext(Thread threadPoolThread)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext()
   at System.Threading.Tasks.AwaitTaskContinuation.RunOrScheduleAction(IAsyncStateMachineBox box, Boolean allowInlining)
   at System.Threading.Tasks.Task.RunContinuations(Object continuationObject)
   at System.Threading.Tasks.Task`1.TrySetResult(TResult result)
   at System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder`1.SetResult(TResult result)
   at System.Net.Security.SslStream.ReadAsyncInternal[TReadAdapter](TReadAdapter adapter, Memory`1 buffer)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecutionContextCallback(Object s)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext(Thread threadPoolThread)
   at System.Runtime.

```

## Root cause

The root cause appears related to the creation of many text fixtures by XUnit, causing some kind of race condition or deadlock. Running the same test within the same context does not produce the exception.

