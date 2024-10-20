# Ép Kiểu

Ép kiểu (type casting) trong C# là việc chuyển đổi một giá trị từ kiểu dữ liệu này sang kiểu dữ liệu khác. C# hỗ trợ hai loại ép kiểu chính:

- **Ép kiểu ngầm định**: Xảy ra khi không có nguy cơ mất dữ liệu (chuyển từ kiểu nhỏ sang kiểu lớn).
##### Ép kiểu ngầm định
```csharp
int a = 10;
double b = a; // int chuyển thành double
```

- **Ép kiểu tường minh**: Yêu cầu lập trình viên chỉ định rõ (chuyển từ kiểu lớn sang kiểu nhỏ).

##### Ép kiểu tường minh
```csharp
double c = 9.8;
int d = (int)c; // double chuyển thành int (mất phần thập phân)
```
# Parse và TryParse

**`Parse`** và **`TryParse`** dùng để chuyển đổi `string` thành các kiểu dữ liệu số.

- **Parse**: Nếu chuỗi không hợp lệ, nó sẽ gây ra ngoại lệ (`Exception`).
- **TryParse**: Tương tự `Parse`, nhưng nó không gây ngoại lệ mà trả về `true` hoặc `false` để kiểm tra thành công.

### Parse
```csharp
string numberStr = "123";
int number = int.Parse(numberStr); // number = 123
```

### TryParse
```csharp
string invalidStr = "abc";
bool success = int.TryParse(invalidStr, out int res); // success = false, res = 0
```

# Convert

Lớp `Convert` cung cấp các phương thức để chuyển đổi các kiểu dữ liệu khác nhau.
```csharp
int myInt = 10;
double myDouble = 5.25;
bool myBool = true;
// convert int to string
Console.WriteLine(Convert.ToString(myInt));  
// convert int to double  
Console.WriteLine(Convert.ToDouble(myInt)); 
// convert double to int   
Console.WriteLine(Convert.ToInt32(myDouble)); 
// convert bool to string 
Console.WriteLine(Convert.ToString(myBool));   
```

# Boxing và Unboxing
Boxing: Chuyển đổi một giá trị kiểu dữ liệu giá trị (value type) thành object.
```csharp
int number = 123;
object boxed = number; // Boxing: Chuyển int thành object
Unboxing
```
Unboxing: Chuyển đổi ngược từ object về kiểu giá trị ban đầu.

```csharp
object obj = 123;
int unboxed = (int)obj; // Unboxing: Chuyển object về int
```