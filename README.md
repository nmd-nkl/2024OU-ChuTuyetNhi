# [GCC 2024] OOP-Unity [Buổi 2]

# Class

Gồm có thuộc tính & phương thức
```csharp
class Car {
    public static float velocity;
    public void Run() {
        Console.WriteLine("Go go!");
    }
    public void ShowVelocity() {

    }
}
```
```csharp
    Car car1 = new Car(); // khởi tạo 1 obj car, gán biến car trỏ đến Car
    var car2 = new Car();
    car1.velocity = 1f;
    car2.velocity = 2f;
    Console.WriteLine($"car 1 velocity: {car1.velocity}, car 2 velocity: {car2.velocity}");
    car1.Run();
```
```csharp
    car1.ShowVelocity(); // out: 0
    Car.velocity = 3f;
    car1.ShowVelocity(); // out : 3
```
`static` thuộc về `class` không riêng về `object`, do đó các `object` sẽ dùng chung biến `static` đó.
`static class` có các hàm bên trong phải là `static`

## Constructor
Mặc định 
```csharp
    public Car() {

    }
```
Tham Số
```csharp
    public Car(float velocity) {
        this.velocity = velocity;
    }
```
khi này `default constructor` nếu muốn sử dụng phải tự khai báo.
## Destructor
```csharp
    var car1 = new Car(1f);
    var car2 = new Car(2f);
    car2 = car1; //obj car2 tự huỷ, cả 2 chỉ đến obj car 1
    car1.velocity = 3f; // do cùng trỏ đến 1 obj car1
    Console.WriteLine($"car 1 velocity: {car1.velocity}, car 2 velocity: {car2.velocity}"); // in ra đều là 3
```
# Inheritance
```csharp
public class Animal {
    public virtual void Speak() {
        Console.WriteLine("Speak!");
    }
}

public class Dog : Animal {
    public override void Speak() {
        Console.WriteLine("Gau Gau");
    }
    public void AnXuong() {
        Console.WriteLine("An Xuong");
    }
}

public class Meo : Animal {
    public override void Speak() {
        Console.WriteLine("Meo Meo");
    }
}

class Program {
    static void Main(string[] args) {
        // Khai báo 1: Biến myDog có kiểu Dog, do đó có thể truy cập tất cả các phương thức của lớp Dog
        Dog myDog = new Dog();
        myDog.Speak();  // Gọi phương thức override Speak() từ lớp Dog -> "Gau Gau"
        myDog.AnXuong(); // Gọi phương thức riêng của Dog -> "An Xuong"

        // Khai báo 2: Biến myDog2 có kiểu Animal nhưng khởi tạo là Dog
        Animal myDog2 = new Dog();
        myDog2.Speak();  // Gọi phương thức override Speak() từ lớp Dog -> "Gau Gau"
        // myDog2.AnXuong(); // Lỗi: Không thể gọi phương thức AnXuong vì biến myDog2 có kiểu Animal
    }
}
```
## Access Modifiers
`public` & `private` & `protected`
# Đóng gói
`set` và `get`
# Abstract <Trừu tượng> & Interface
`abstract Class` cần chứa ít nhất 1 phương thức `abstract` cần được `override` lại.
- có thể kế thừa nhiều `Interface`
# Ref và Out
```csharp
    public void Modify(ref int x) {
        x += 5;
    }
```
```csharp
    int n = 5;
    Modify(ref n);
    Console.WriteLine(n);
```
```csharp
    public static void Calc(int r, out int C, out int area) {
        C = 2 * r;
        area = r * r;
    }
```
```csharp
    int b = 1, c = 2;
    Calc(n, out b, out c); // 10 //25
    Console.WriteLine($"b: {b}, c: {c}");
```
# Mảng 
Như c++, lưu ý khai báo mảng 2 chiều
```csharp
    int[,] matrix = new int[3, 4];
```
