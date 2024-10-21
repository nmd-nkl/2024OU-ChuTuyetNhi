## Mục lục
1. [OOP](#oop)
2. [Class](#class)
    - [Constructor & Destructor](#constructor--destructor)
    - [C# Access Modifiers](#c-access-modifiers)
3. [Encapsulation](#encapsulation)
4. [Inheritance](#inheritance)
5. [Polymorphism](#polymorphism)
6. [Abstraction](#abstraction)

---
# `OOP`
**OOP (Object-Oriented Programming)** là một phương pháp lập trình dựa trên việc sử dụng đối tượng và lớp. Nó giúp chia nhỏ các vấn đề phức tạp thành các phần nhỏ hơn, dễ quản lý và phát triển hơn. OOP có 4 đặc trưng chính:

- **Tính đóng gói (Encapsulation)**: Dữ liệu và các phương thức liên quan được đóng gói trong một đối tượng. Chỉ các thành phần bên trong đối tượng đó mới có thể truy cập được.

- **Tính kế thừa (Inheritance)**: Một lớp có thể kế thừa các thuộc tính và phương thức của lớp khác.

- **Tính đa hình (Polymorphism)**: Cho phép một phương thức hoặc thuộc tính có nhiều cách sử dụng khác nhau (thông qua overload hoặc override).

- **Tính trừu tượng (Abstraction)**: Giấu đi các chi tiết thực thi phức tạp, chỉ cung cấp cho người dùng những thông tin cần thiết.
---
# `Class`
Class (lớp) là một khuôn mẫu để tạo ra các đối tượng (object). Nó chứa các thuộc tính (attributes) và phương thức (methods) để mô tả hành vi và trạng thái của đối tượng.
```csharp
public class Car
{
    // Thuộc tính
    public string brand, model;
    public int year;
    // Phương thức
    public void Start()
    {
        Console.WriteLine("The car is starting.");
    }
}

//Sử dụng:
Car myCar = new Car();
myCar.brand = "Toyota";
myCar.model = "Corolla";
myCar.year = 2020;

Console.WriteLine(myCar.brand);  // Output: Toyota
myCar.Start();  // Output: The car is starting.
```

## `Constructor` & `Destructor`
| Constructor| Destructor|
|---|---|
| Được gọi khi tạo đối tượng| Được gọi khi đối tượng bị hủy để giải phóng tài nguyên|
| Khởi tạo giá trị cho thuộc tính| Thường dùng để giải phóng tài nguyên không được quản lý bởi bộ nhớ|
| Có cùng tên với lớp, có thể có tham số| Có cùng tên với lớp, thêm dấu `~`, không có tham số và không overload|
| Tự động cung cấp constructor mặc định nếu không định nghĩa | Tự động gọi bởi garbage collector khi đối tượng không còn được dùng |
```csharp
public class Car
{
    public string brand, model;
    public int year;
    // Constructor
    public Car(string brand, string model, int year)
    {
        this.brand = brand; this.model = model;
        this.year = year;
    }

    // Destructor
    ~Car()
    {
        Console.WriteLine($"{brand} is destroyed.");
    }
    public void Start()
    {
        Console.WriteLine($"{brand} {model} is starting.");
    }
}

class Program
{
    static void Main()
    {
        // Tạo một đối tượng Car và truyền giá trị cho constructor
        Car myCar = new Car("Honda", "Civic", 2021);
        myCar.Start();  // Output: Honda Civic is starting.
    }
}
```
## `C# Access Modifiers`

| Access Modifier | Mô tả                                                                 | Accessibility Level                                |
|------------------|-----------------------------------------------------------------------------|----------------------------------------------------|
| `public`         | Thành viên có thể được truy cập từ bất kỳ đâu.                            | Tất cả các lớp trong ứng dụng                     |
| `private`        | Thành viên chỉ có thể được truy cập từ bên trong lớp chứa nó.              | Lớp chứa thành viên                                |
| `protected`      | Thành viên có thể được truy cập từ lớp chứa nó và các lớp kế thừa.        | Lớp chứa và các lớp con                           |
| `internal`       | Thành viên chỉ có thể được truy cập từ trong cùng một assembly.           | Tất cả các lớp trong cùng assembly                 |
| `protected internal` | Thành viên có thể được truy cập từ lớp chứa, lớp kế thừa, và từ cùng một assembly. | Lớp chứa, lớp con và cùng assembly                |
---
# `Encapsulation`
- Đảm bảo dữ liệu được bảo mật
- Khai báo biến là `private` và cung cấp `public` `get`,  `set` methods
```csharp
class Person
{
  private string name; // field
  public string Name   // property
  {
    get { return name; }
    set { name = value; }
  }
}
//sử dụng:
myObj.Name = "Liam";
```
rút gọn:
```csharp
class Person
{
  public string Name  // property
  { get; set; }
}
```
---
# `Inheritance`
- **Derived Class (child)** kế thừa các thuộc tính và phương thức từ một lớp khác **Base Class (parent)**
- Giúp tái sử dụng mã và tạo ra cấu trúc phân cấp.
- C# chỉ cho kế thừa từ 1 lớp cha
- **`sealed` chặn Class khác kế thừa từ Class này**
```csharp
public class ParentClass
{
    public void Display()
    {
        Console.WriteLine("This is a method from the Parent Class.");
    }
}

public class ChildClass : ParentClass
{
    public void Show()
    {
        Console.WriteLine("This is a method from the Child Class.");
    }
}

class Program
{
    static void Main()
    {
        ChildClass child = new ChildClass();
        child.Display();  // Output: This is a method from the Parent Class.
        child.Show();     // Output: This is a method from the Child Class.
    }
}
```
---
# `Polymorphism`
Đa hình cho phép các phương thức có cùng tên nhưng hành vi khác nhau tùy theo ngữ cảnh.

C# hỗ trợ hai loại đa hình:
```
1. Đa hình biên dịch (Compile-time polymorphism)
2. Đa hình thời gian chạy (Runtime polymorphism)
```
### 1. Đa Hình Biên Dịch (Method Overloading)

Đa hình biên dịch được thực hiện thông qua nạp chồng phương 
thức, cho phép định nghĩa nhiều phương thức có cùng tên nhưng 
khác nhau về số lượng hoặc kiểu tham số.

```csharp
public class Calculator
{
    // Nạp chồng phương thức
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}
```
### 2. Đa Hình Thời Gian Chạy (Method Overriding)

Khi một lớp con định nghĩa lại phương thức đã được định nghĩa trong lớp cha.

Để thực hiện điều này, lớp cha phải sử dụng từ khóa `virtual`, và lớp con phải sử dụng từ khóa `override`.

Ví dụ:

```csharp
public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal speaks");
    }
}

public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}

class Program
{
    static void Main()
    {
        Animal myDog = new Dog();
        myDog.Speak();  // Output: Dog barks
    }
}
```
## Nạp chồng toán tử

C# cho phép định nghĩa cách hoạt động của các toán tử đối với các kiểu dữ liệu tùy chỉnh.

```csharp
public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public static Point operator +(Point p1, Point p2)
    {
        return new Point { X = p1.X + p2.X, Y = p1.Y + p2.Y };
    }
}
```

---
# `Abstraction`
Để đạt được bảo mật - hãy ẩn data và chỉ hiển thị các chi tiết quan trọng của một đối tượng.

Từ khóa `abstract` được sử dụng cho lớp và phương thức:

- **`abstract class`**: là một lớp bị hạn chế, không thể dùng để tạo đối tượng (để truy cập vào nó, phải kế thừa từ một lớp khác).

- **`abstract method`**: chỉ có thể được sử dụng trong lớp trừu tượng và không có phần thân. Phần thân sẽ được cung cấp bởi lớp dẫn xuất (kế thừa từ đó).

```csharp
abstract class Animal
{
    public abstract void MakeSound(); // abstract method
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof!"); // Phần thân được cung cấp bởi lớp Dog
    }
}
```
## `Interface`

Interface định nghĩa một tập hợp các phương thức mà các lớp thực thi phải triển khai. Interface không thể chứa các thuộc tính hoặc phương thức có thân phương thức (body).

```csharp
public interface IAnimal
{
    void Speak();
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Cat meows");
    }
}

public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}

class Program
{
    static void Main()
    {
        IAnimal myCat = new Cat();
        IAnimal myDog = new Dog();

        myCat.Speak();  // Output: Cat meows
        myDog.Speak();  // Output: Dog barks
    }
}
```

#### Lợi ích của Interface

- Interface giúp đạt được tính đa hình và tách biệt giữa các phương thức đã định nghĩa và cách chúng được triển khai.
- Cho phép xây dựng các hệ thống linh hoạt và dễ bảo trì hơn.