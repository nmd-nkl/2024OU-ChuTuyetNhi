## [GCC 2024] OOP-Unity [BUỔI 3]
### Ghi chú trên lớp
# 1. Namespace
**`Namespace`** là một vùng định danh để quản lý và sắp xếp các lớp (class), phương thức (method), và các đối tượng (object) trong chương trình. Nó giúp tránh xung đột tên (name conflict) trong mã nguồn khi các lớp hoặc phương thức có tên trùng nhau.
Trong một namespace, có thể tạo nhiều lớp (class) cùng trong một file hoặc tách ra trong các file khác nhau. Ví dụ:
  - **Cùng một namespace và cùng một file**: Có hai class A và B nằm trong cùng một file và cùng namespace.
  - **Cùng một namespace nhưng khác file**: Có hai class A và B nằm trong hai file khác nhau nhưng cùng chung một namespace.

# 2. Static
**Static** có thể được truy cập mà không cần khởi tạo một đối tượng và nó là DUY NHẤT.
  - **Static Class**: Lớp `static` không thể khởi tạo và chỉ có thể chứa các thành phần `static`. Tất cả các thuộc tính (properties) và phương thức (methods) bên trong lớp `static` đều phải được khai báo là `static`.
  - **Static Field/Variable**: Biến `static` được khởi tạo một lần duy nhất trong suốt vòng đời của ứng dụng. Thông thường được sử dụng để lưu trữ các giá trị hoặc cấu hình dùng chung trong toàn bộ ứng dụng.
  - **Static Method**: Phương thức `static` có thể được gọi mà không cần tạo đối tượng của lớp chứa phương thức đó.
```csharp
public static class MathAdd
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}
// Sử dụng
int result = MathAdd.Add(5, 10); // Không cần khởi tạo đối tượng MathAdd
```

#### 3. Unity cơ bản
- **GameObject**
- **Component**
    - Rigid Body
    - SpriteRender
- **Camera**
- **Pivot**
- **Scene**
- **Tag**
- **Sorting Layer và Order In Layer**
- **Inspecto**
- **Hierarchy**

