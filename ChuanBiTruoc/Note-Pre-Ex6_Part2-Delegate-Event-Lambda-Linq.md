# MỤC LỤC
- [Delegate](#delegate)
  - [Func Delegate](#func-delegate)
  - [Action Delegate](#action-delegate)
  - [Predicate Delegate](#predicate-delegate)
  - [Multicast Delegate](#multicast-delegate)
- [Event](#event)
- [Lambda Expressions](#lambda-expressions)
- [LINQ](#linq)
--- 
# Delegate
- Tương tự như con trỏ hàm trong C hoặc C++
- `Delegate` là một biến kiểu tham chiếu(references) chứa tham chiếu tới một phương thức
- Tham chiếu của `Delegate` có thể thay đổi **runtime** 
- `Delegate` thường được dùng để triển khai các phương thức hoặc sự kiện call-back.
```
[access modifier] delegate [return type] [delegate name]([parameters])
```
### Khai báo và sử dụng Delegate
#### 1. **Khai báo delegate**
```csharp
public delegate void MyDelegate(string msg);
```
Ở đây, `MyDelegate` là một delegate có thể tham chiếu đến bất kỳ phương thức nào trả về `void` và có một tham số kiểu `string`.
#### 2. Set target cho `Delegate`
```csharp
public delegate void MyDelegate(string msg); // Khai báo delegate
// set target method
MyDelegate del = new MyDelegate(MethodA);
// or 
MyDelegate del = MethodA; 
// target method
static void MethodA(string message)
{
    Console.WriteLine(message);
}
```
#### 3. Invoke (Sử dụng)
```csharp
del.Invoke("Hello World!");
// or 
del("Hello World!");
```
## `Func Delegate`
- Là 1 `generic delegate`
```csharp
public delegate TResult Func<input T1, input T2, output TResult>(T1 arg1, T2 arg2);
```
Tham số cuối cùng trong <> luôn là giá trị trả về.

Ví dụ: 
```csharp
static int Sum(int x, int y)
    {
        return x + y;
    }

    static void Main(string[] args)
    {
        Func<int,int, int> add = Sum;

        int result = add(10, 10);

        Console.WriteLine(result); 
    }
```
**`Func delegate`** có thể có 0 -> 16 tham số **input**, tuy nhiên phải có tham số **out** (phải có trả về giá trị).

### Func với Anonymous Method (Phương thức không có tên)
```csharp
Func<int> getRandomNumber = delegate()
                            {
                                Random rnd = new Random();
                                return rnd.Next(1, 100);
                            };
//Or
Func<int> getRandomNumber = () => new Random().Next(1, 100);
//Or 
Func<int, int, int>  Sum  = (x, y) => x + y;
```
## `Action Delegate`
- Giống `Func delegate` tuy nhiên `Action Delegate` không yêu cầu phải có giá trị trả về, chỉ cần biến input truyền vào.

Delegate:
```csharp
public delegate void Print(int val);

static void ConsolePrint(int i)
{
    Console.WriteLine(i);
}

static void Main(string[] args)
{           
    Print prnt = ConsolePrint;
    prnt(10);
}
```
Tuy nhiên có thể sử dụng: `Action Delegate`
```csharp
static void ConsolePrint(int i)
{
    Console.WriteLine(i);
}
static void Main(string[] args)
{   
    //KHỞI TẠO
    Action<int> printActionDel = ConsolePrint;
    //Or
    Action<int> printActionDel = new Action<int>(ConsolePrint);
    // Or
    Action<int> printActionDel = i => Console.WriteLine(i);
    printActionDel(10);
}
```
Một Anonymous method có thể gán cho một `Action Delegate`:
```csharp
Action<int> printActionDel = delegate(int i)
                                {
                                    Console.WriteLine(i);
                                };

printActionDel(10);
```
### `Predicate Delegate`
**`Predicate`** tương đương 1 delegate với kiểu trả về là **bool**, với in là các param nhận vào. **`Predicate`** chỉ có thể nhận vào **1 param duy nhất**.
```csharp
static bool IsUpperCase(string str)
{
    return str.Equals(str.ToUpper());
}
static void Main(string[] args)
{
    Predicate<string> isUpper = IsUpperCase;

    bool result = isUpper("hello world!!");

    Console.WriteLine(result); //out: false
}
```
#### Với Anonymous method
```csharp
static void Main(string[] args)
{
    Predicate<string> isUpper = delegate(string s) { return s.
    //or Lambda expression:
    Predicate<string> isUpper = s => s.Equals(s.ToUpper());

    Equals(s.ToUpper());};
    bool result = isUpper("hello world!!");
}
```
### `Multicast Delegate`

**`Delegate`** có thể tham chiếu đến nhiều phương thức cùng một lúc. Khi gọi **`Delegate`** đó, tất cả các phương thức trong danh sách sẽ được gọi **theo thứ tự thêm vào**.
Ví dụ:
```csharp
public static void Method1(string message)
{
    Console.WriteLine("Method1: " + message);
}

public static void Method2(string message)
{
    Console.WriteLine("Method2: " + message);
}

public static void Main()
{
    MyDelegate del1 = new MyDelegate(Method1);
    MyDelegate del2 = new MyDelegate(Method2);
    // Multicast delegate
    MyDelegate del = del1 + del2;
    // Gọi cả Method1 và Method2
    del("Hello Multicast");
}
```
Kết quả:
```
Method1: Hello Multicast
Method2: Hello Multicast
```
---
# Event
[Event-Video giải thích](https://youtu.be/OuZrhykVytg?si=9-yrBJ4KkO3402nn) **By CodeMonkey**
- Là cơ chế để một đối tượng (đối tượng của lớp) này thông báo đến đối tượng khác có điều gì đó mà lớp khác quan tâm vừa xảy ra. 
- Lớp mà từ đó gửi đi sự kiện gọi là **publisher** và các lớp nhận được sự kiện gọi là là các **subsriber**
- **Khai báo sự kiện**: Để khai báo sự kiện trong C#, thực hiện hai bước:
    - B1: Khai báo delegate.
    - B2. Khai báo biến delegate với từ khóa `event`.

    - **Ví dụ**: 
  ```csharp
  public delegate void Notify(); // khai báo delegate

  public class ProcessBusinessLogic
  {
      public event Notify ProcessCompleted; // khai báo sự kiện
  }
  ```
- **Invoke Event**:
  ```csharp
  public void StartProcess()
  {
      Console.WriteLine("Process Started!");
      OnProcessCompleted(); // kích hoạt sự kiện
  }
  protected virtual void OnProcessCompleted()
  {
      ProcessCompleted?.Invoke(); // nếu không null thì gọi
  }
  ```

- **Sử dụng Event**:
  ```csharp
  class Program
  {
      static void Main()
      {
          ProcessBusinessLogic bl = new ProcessBusinessLogic();
          bl.ProcessCompleted += bl_ProcessCompleted; // đăng ký sự kiện
          bl.StartProcess();
      }

      static void bl_ProcessCompleted()
      {
          Console.WriteLine("Process Completed!");
      }
  }
  ```
  - Lớp `Program` đăng ký xử lý sự kiện bằng cách sử dụng toán tử **`+=`**. Huỷ đăng khí bằng **`-=`**

- **Sử dụng `EventHandler` có sẵn**:
  - Thay vì khai báo delegate tùy chỉnh, có thể dùng `EventHandler` hoặc `EventHandler<TEventArgs>`.
  - Ví dụ:
    ```csharp
    public class ProcessBusinessLogic
    {
        //built-in EventHandler
        public event EventHandler ProcessCompleted; 

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            OnProcessCompleted(EventArgs.Empty); //No event data
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }
    ```
    
    ```csharp 
    public class ProcessBusinessLogic
    {
        public event EventHandler<bool> ProcessCompleted; 
        public void StartProcess()
        {
            try
            {
                Console.WriteLine("Process Started!");
                OnProcessCompleted(true);
            }
            catch(Exception ex)
            {
                OnProcessCompleted(false);
            }
        }

        protected virtual void OnProcessCompleted(bool IsSuccessful)
        {
            ProcessCompleted?.Invoke(this, IsSuccessful);
        }
    }

- **Truyền dữ liệu `Event`**:
  - Có thể sử dụng `EventArgs` để truyền dữ liệu, hoặc tạo lớp tùy chỉnh kế thừa từ `EventArgs`.
  - Ví dụ:
    ```csharp
    class ProcessEventArgs : EventArgs
    {
        public bool IsSuccessful { get; set; }
        public DateTime CompletionTime { get; set; }
    }
    ```

    - Ví dụ sử dụng:
    ```csharp
    public class ProcessBusinessLogic
    {
        public event EventHandler<ProcessEventArgs> ProcessCompleted; 
        public void StartProcess()
        {
            var data = new ProcessEventArgs();
            try
            {
                Console.WriteLine("Process Started!");

                data.IsSuccessful = true;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
            catch(Exception ex)
            {
                data.IsSuccessful = false;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
        }
        protected virtual void OnProcessCompleted(ProcessEventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }
    ```
---
# Lambda Expressions
Được dùng như `anonymous functions`

Chúng thường được sử dụng với `delegate` và các phương thức `LINQ`

Có 2 loại:
### Expression Lambda
```csharp
input => expression;
```
### Statement Lambda
```csharp
input => { statements };
```
Ví dụ:
```csharp
static void Main()
{
    Func<int, int> square = x => x * x;
    Console.WriteLine($"Square of 5: {square(5)}");
}
```
```csharp
// or set lambda expression 
MyDelegate del = (string msg) =>  Console.WriteLine(msg);
```
---
# LINQ
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Dữ liệu mẫu
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Age = 20 },
            new Student { Id = 2, Name = "Bob", Age = 22 },
            new Student { Id = 3, Name = "Charlie", Age = 21 }
        };
        var scores = new List<Score>
        {
            new Score { StudentId = 1, Value = 85 },
            new Score { StudentId = 2, Value = 90 },
            new Score { StudentId = 3, Value = 78 }
        };

        // 1. Lọc (Where): Lấy các số chẵn
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

        // 2. Sắp xếp (OrderBy): Sắp xếp số giảm dần
        var sortedNumbers = numbers.OrderByDescending(n => n);
        Console.WriteLine("Sorted Numbers: " + string.Join(", ", sortedNumbers));

        // 3. Nhóm (GroupBy): Nhóm các số theo số dư khi chia cho 3
        var groupedNumbers = numbers.GroupBy(n => n % 3)
                                    .Select(g => new { Key = g.Key, Values = g.ToList() });
        foreach (var group in groupedNumbers)
        {
            Console.WriteLine($"Group {group.Key}: {string.Join(", ", group.Values)}");
        }

        // 4. Chọn (Select): Lấy danh sách bình phương của các số
        var squaredNumbers = numbers.Select(n => n * n);
        Console.WriteLine("Squared Numbers: " + string.Join(", ", squaredNumbers));

        // 5. Tổng hợp (Aggregate): Tính tổng các số
        int sum = numbers.Sum();
        Console.WriteLine("Sum of Numbers: " + sum);

        // 6. Kết hợp (Join): Kết hợp danh sách sinh viên với điểm số
        var studentScores = from student in students
                            join score in scores on student.Id equals score.StudentId
                            select new { student.Name, score.Value };
        foreach (var item in studentScores)
        {
            Console.WriteLine($"{item.Name}: {item.Value}");
        }

        // 7. Thực thi ngay lập tức (Immediate Execution): ToList() để thực thi truy vấn
        var immediateList = evenNumbers.ToList(); // Thực thi ngay lập tức

        // 8. Deferred Execution: Truy vấn chỉ thực thi khi sử dụng kết quả
        var deferredQuery = numbers.Where(n => n > 5); // Chưa thực thi
        Console.WriteLine("Deferred Execution: " + string.Join(", ", deferredQuery));
    }
}

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class Score
{
    public int StudentId { get; set; }
    public int Value { get; set; }
}

```