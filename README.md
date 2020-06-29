# Toolkit
### .NET Toolkit include tools for comfortable dev

#### Content
<ul>
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
  
  Logic checks:
  ```csharp
  Contract.MoreOrEqualThan<int, InvalidOperationException>(first, second);
  ```
  
  </li>
  
  <li>
  Check - a static class similar to the Contract class, but returns a Boolean value instead of throwing an exception.
  
  ```csharp
  if (Check.NotNull<object>(obj)) // true if obj isn't null
  ```  
  
  String checks:
  
  ```csharp
  string str = "";
  if (Check.StringNotNullOrWhiteSpace(str)) // false because str is empty
  ```   
  </li>
  
  <li>
  Condition - allows you to build a chain of logical conditions.
  
  ```csharp
  int a = 10;
  int b = 20;
  var result = Condition
               .Check(a == 10)
               .And(b == 20);
               .Or(b == 5)
               .Not() // now it's false
  ```
  </li>

  <li>
  
  BaseViewModel contains an implementation of the `INotifyPropertyChanged` interface with the `OnPropertyChanged()` method to notify observers about a change in the value of the observed object.
  
  The generic `SetProperty` method is designed to assign values to observable objects and notify about their change.
  </li>
  
  <li>
  And many others...
  </li>
</ul>

### See the [wiki](https://github.com/DepthRel/Toolkit/wiki) for more details.

###### DepthRel, 2020
