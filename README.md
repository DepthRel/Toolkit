# Toolkit
### .NET Toolkit include tools for ViewModels and contracts for checks logical conditions

#### Content
<ul>
  <li>
  
  BaseViewModel contains an implementation of the `INotifyPropertyChanged` interface with the `OnPropertyChanged()` method to notify observers about a change in the value of the observed object.
  
  The generic `SetProperty` method is designed to assign values to observable objects and notify about their change.
  </li>
  <li>
  
  Contracts - a way to verify the transferred parameters in a concise way. Contracts are intended to replace the cumbersome constructions of condition checks, such as:
  ```csharp
  if (string.IsNullOrWhiteSpace(str?.Trim()))
  {
       throw new Exception("The value is incorrect");
  }
  ```
  Instead, just write:
  ```csharp
  Contract.StringNotNullOrWhiteSpace<Exception>(str);
  ```
  
  The same goes for null checks:
  ```csharp
  Contract.NotNull<object, ArgumentNullException>(obj);
  ```
  
  Logic Checks:
  ```csharp
  Contract.MoreOrEqualThan<int, InvalidOperationException>(first, second);
  ```
  
  And many others...
  </li>
</ul>


###### DepthRel, 2020
