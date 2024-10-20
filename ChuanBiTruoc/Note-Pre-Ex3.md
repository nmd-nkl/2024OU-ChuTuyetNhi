# Var
Từ khóa `var` cho phép trình biên dịch suy ra kiểu của biến dựa trên giá trị được gán cho nó. Nó chỉ có thể được sử dụng khi giá trị gán cho biến đã xác định rõ kiểu
```csharp
var number = 10;  // Kiểu của number là int
var text = "Hello";  // Kiểu của text là string
```
# Dynamic
Từ khóa `dynamic` cho phép một biến thay đổi kiểu dữ liệu lúc **runtime**. Không giống var, kiểu của dynamic không được xác định tại thời điểm biên dịch mà chỉ tại thời gian chạy.
```csharp
dynamic data = 10;
Console.WriteLine(data);  // In ra 10 (kiểu int)
data = "Hello";
Console.WriteLine(data);  // In ra Hello (kiểu string)
```
Lưu ý: Sử dụng dynamic có thể dẫn đến lỗi chỉ được phát hiện tại thời gian chạy, cần thận trọng khi dùng.
# ref và out
Cả `ref` và `out` đều được sử dụng để truyền tham số đến phương thức, cho phép phương thức sửa đổi giá trị của tham số bên ngoài.

1. **Khởi tạo**:
   - **`ref`**: Tham số **cần được khởi tạo** trước khi được truyền vào phương thức (gán giá trị cho biến trước)
   - **`out`**: Tham số **không cần được khởi tạo** trước khi được truyền vào phương thức. **Tuy nhiên, phương thức phải gán một giá trị cho tham số trước khi nó kết thúc.**

2. **Cú pháp**:

   ```csharp
   void MethodRef(ref int x) { x += 10; }
   void MethodOut(out int y) { y = 20; }

   int a = 5;
   MethodRef(ref a); // a bây giờ là 15

   int b;
   MethodOut(out b); // b bây giờ là 20
   ```