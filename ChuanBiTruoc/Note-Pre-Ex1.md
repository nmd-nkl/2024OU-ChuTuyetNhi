# Các biến trong C#

```csharp
<kiểu dữ liệu> <tên biến> = <giá trị khởi tạo>;
```

Ví dụ:
```csharp
int myNum = 5;               // Integer (whole number)
double myDoubleNum = 5.99D;  // Floating point number
char myLetter = 'D';         // Character
bool myBool = true;          // Boolean
string myText = "Hello";     // String
```

## 1. Phân loại biến
Biến trong C# có thể được phân loại thành các loại chính sau:

- **Biến cục bộ (Local Variable):** Được khai báo bên trong một phương thức, khối lệnh, hoặc hàm. Chỉ có thể được truy cập trong phạm vi khai báo của nó.
  
  ```csharp
  void Method()
  {
      int localVar = 10; // Biến cục bộ
  }
  ```

- **Biến thành viên (Instance Variable):** Được khai báo bên trong lớp, nhưng bên ngoài bất kỳ phương thức nào. Chúng là các biến được liên kết với đối tượng của lớp.

  ```csharp
  class MyClass
  {
      int instanceVar = 5; // Biến thành viên
  }
  ```

- **Biến tĩnh (Static Variable):** Được khai báo với từ khóa `static` và thuộc về lớp chứ không phải đối tượng của lớp. Có thể truy cập trực tiếp thông qua tên lớp.

  ```csharp
  class MyClass
  {
      static int staticVar = 10; // Biến tĩnh
  }
  ```

## 2. Kiểu dữ liệu
Trong C#, kiểu dữ liệu của biến có thể là:

- **Kiểu dữ liệu giá trị (Value Types):** Bao gồm các kiểu dữ liệu như `int`, `float`, `double`, `bool`, `char`, `struct`, `enum`.
  
  ```csharp
  int number = 100;
  float price = 10.5f;
  bool isActive = true;
  ```

- **Kiểu dữ liệu tham chiếu (Reference Types):** Bao gồm `string`, `array`, `class`, `interface`, `delegate`.

  ```csharp
  string message = "Hello, C#";
  int[] numbers = { 1, 2, 3, 4 };
  ```

## 3. Biến hằng số (Constant)
Biến hằng số được khai báo bằng từ khóa `const` và có giá trị cố định không thay đổi trong suốt chương trình.

```csharp
const double Pi = 3.14159;
```

## 4. Biến đọc (Read-Only)
Được khai báo bằng từ khóa `readonly`, có thể gán giá trị tại thời điểm khai báo hoặc trong hàm khởi tạo (constructor). Giá trị của biến `readonly` không thể thay đổi sau khi đã được gán.

```csharp
readonly int readOnlyVar = 100;
```
## 5. Quy tắc đặt tên biến
- Tên biến phải bắt đầu bằng một chữ cái hoặc dấu gạch dưới (`_`), không được bắt đầu bằng số.
- Có thể chứa các ký tự chữ, số và dấu gạch dưới.
- Phân biệt chữ hoa và chữ thường (ví dụ: `age` và `Age`)

# Stack và Heap
Bộ nhớ trong C# chia thành 2 vùng `Stack` và `Heap`

`Stack` :  Lưu trữ các biến **kiểu giá trị** (value types) và có cơ chế quản lý tự động (**LIFO**)
+ Stack có kích thước nhỏ và nhanh.

`Heap` : Lưu trữ các biến **kiểu tham chiếu** (reference types). Khi một đối tượng được tạo, nó nằm trên heap, và hệ thống sẽ quản lý bộ nhớ thông qua cơ chế **garbage collection**.

## Thứ tự ưu tiên của toán tử
```
Số học (*, /, % ưu tiên cao hơn +, -) > Quan hệ > Logic > Gán
```