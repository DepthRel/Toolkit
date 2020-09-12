# Toolkit
### .NET Toolkit is a tool for simplify the development of classes, business logic, UI elements, etc.

## [Toolkit](https://github.com/DepthRel/Toolkit/tree/master/src/Toolkit)
<ul>
  <li>
    
  [Contracts](https://github.com/DepthRel/Toolkit/wiki/Contract) - a way to verify the transferred parameters in a concise way. Contracts are intended to replace the cumbersome constructions of condition checks, such as:
  
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
  
  [Check](https://github.com/DepthRel/Toolkit/wiki/Check) - a static class similar to the Contract class, but returns a Boolean value instead of throwing an exception.
  
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
  
  [Condition](https://github.com/DepthRel/Toolkit/wiki/Condition) - allows you to build a chain of logical conditions.
  
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
  And others...
  </li>
</ul>
  
  ## [Toolkit.Components](https://github.com/DepthRel/Toolkit/tree/master/src/Toolkit.Components)
  
<ul>
  
  <li>
  
  [BaseViewModel](https://github.com/DepthRel/Toolkit/wiki/BaseViewModel) contains an implementation of the `INotifyPropertyChanged` interface with the `OnPropertyChanged()` method to notify observers about a change in the value of the observed object.
  
  The generic `SetProperty` method is designed to assign values to observable objects and notify about their change.
  </li>
  
  <li>
  
  [IMessage](https://github.com/DepthRel/Toolkit/blob/master/src/Toolkit.Components/Notifications/IMessage.cs) is an interface for solving the problem of calling a dialog from a ViewModel without interacting with the View layer.
  
  ```csharp
  // View layer
  public class Message : IMessage
  {
      public void Report() { MessageBox.Show("Message for user" );
  }
  
  public MainWindow()
  {
      DataContext = new ViewModel(new Message());
  }
  
  // ViewModel layer
  class ViewModel
  {
      public ViewModel(IMessage message)
      {
          message.Report();
      }
  }
  ```
  </li>
  
  <li>
  And others...
  </li>
</ul>

  ## [Toolkit.UI.WPF](https://github.com/DepthRel/Toolkit/tree/master/src/Toolkit.UI.WPF)
  
<ul>
  
  <li>
  
  [PlaceholderTextBox](https://github.com/DepthRel/Toolkit/blob/master/src/Toolkit.UI.WPF/Controls/PlaceholderTextBox.xaml.cs), [NumberBox](https://github.com/DepthRel/Toolkit/blob/master/src/Toolkit.UI.WPF/Controls/NumberBox.xaml.cs), [CompactButton](https://github.com/DepthRel/Toolkit/blob/master/src/Toolkit.UI.WPF/Controls/CompactButton.xaml.cs), [FontIcon](https://github.com/DepthRel/Toolkit/blob/master/src/Toolkit.UI.WPF/Controls/FontIcon.xaml.cs)
  
  ![Controls](https://i.ibb.co/whQZ5VP/image.png)
  
  </li>
  
  <li>
  
  [DialogBox](https://github.com/DepthRel/Toolkit/blob/master/src/Toolkit.UI.WPF/Controls/DialogBox.xaml.cs)
  
  ![DialogBox](https://i.ibb.co/JdS6s5X/image.png)
  
  <li>
  And others...
  </li>
</ul>

### See [wiki](https://github.com/DepthRel/Toolkit/wiki) for more details.

###### [DepthRel](https://github.com/DepthRel), 2020
