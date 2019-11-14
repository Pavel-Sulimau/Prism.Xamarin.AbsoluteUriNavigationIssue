### This application demonstrates the ambiguity that you may encounter with Prism's new (introduced in v7.2) `InitializeAsync` method.

The example app has 3 view models
* `MainPageViewModel`
* `FirstPageViewModel`
* `SeconPageViewModel`

`FistPageViewModel` overrides `InitializeAsync` method putting 3 seconds delay inside it
```csharp
public override async Task InitializeAsync(INavigationParameters parameters)
{
    await Task.Delay(3000); // simulate long data loading
}
```

whereas `SecondPageViewModel` overrides `InitializeAsync` method putting 0.5 seconds delay
```csharp
public override async Task InitializeAsync(INavigationParameters parameters)
{
    await Task.Delay(500); // simulate data loading
}
```

`MainPageViewModel` navigates to `SecondPageViewModel` through `FirstPageViewModel`
```csharp
await NavigateToPageAsync("FirstPage/SecondPage")
```

If a user navigates to `SecondPage` and presses 'Back button' before `FirstPageViewModel` has completed its initialization (which takes at least 3 seconds in this example), then the backward navigation leads the user to `MainPage`

<img src="https://user-images.githubusercontent.com/8143332/68886698-bda4c580-0728-11ea-9a8a-13df56dbb0c1.gif" width="300" height="600">

**but** if the user presses 'Back button' after `FirstPageViewModel` has finished its initialization in background (pay attention to how 'Back button' changes after it happens), then the backward navigation lead the user to `FirstPageViewModel` which may be ambiguous to the user

<img src="https://user-images.githubusercontent.com/8143332/68886982-3ad03a80-0729-11ea-99e7-aec8cb3ad791.gif" width="300" height="600">
