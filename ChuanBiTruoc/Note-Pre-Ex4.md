# Mảng 1 chiều
### khởi tạo mảng
```csharp
// Khởi tạo mảng với giá trị cụ thể
int[] nums = { 1, 2, 3, 4, 5 };
// Hoặc khởi tạo mảng rỗng và gán giá trị sau
int[] nums = new int[5];
```
### Lặp qua mảng
```csharp
// Sử dụng vòng lặp for
for (int i = 0; i < nums.Length; i++) {
    Console.WriteLine(nums[i]);
}
// Sử dụng vòng lặp foreach
foreach (int num in nums) {
    Console.WriteLine(num);
}
```
# Mảng 2 chiều
### Khởi tạo mảng
```csharp
// Khởi tạo mảng hai chiều với giá trị cụ thể
int[,] matrix = 
{
    { 1, 2, 3, 4 },
    { 5, 6, 7, 8 },
    { 9, 10, 11, 12 }
};
// Hoặc khởi tạo mảng rỗng và gán giá trị sau
int[,] matrix = new int[3, 4];
```
### Lặp qua mảng
```csharp
// Sử dụng vòng lặp for lồng nhau
for (int i = 0; i < matrix.GetLength(0); i++) // Đếm hàng
{
    for (int j = 0; j < matrix.GetLength(1); j++) // Đếm cột
    {
        Console.Write(matrix[i, j] + " ");
    }
}
// Sử dụng vòng lặp foreach
foreach (int value in matrix)
{
    Console.Write(value + " ");
}
```
# Lớp String
| Tên phương thức | Ý nghĩa | Ghi chú |
|-|-|-|
| `Remove(int startIndex, int count)`| Trả về chuỗi mới đã gỡ bỏ `count` ký tự từ vị trí `startIndex`.| |
| `Replace(char oldValue, char newValue)`| Trả về chuỗi mới thay thế các ký tự `oldValue` bằng ký tự `newValue`.||
| `Split(char value)`| Trả về mảng các chuỗi được cắt tại những nơi có ký tự `value`.| Có thể truyền vào nhiều ký tự. Thực hiện tách theo từng ký tự.|
| `Substring(int startIndex, int length)`| Trả về chuỗi mới từ vị trí `startIndex` với số ký tự là `length`.| Nếu chỉ truyền `startIndex`, sẽ cắt từ đó đến cuối chuỗi.|
| `String.Compare(string strA, string strB)`| So sánh hai chuỗi `strA` và `strB`. Trả về 0 nếu bằng nhau, 1 nếu `strA > strB`, -1 nếu ngược lại.| Có thể gọi qua `<tên biến>.CompareTo(string strB)`.|
| `String.Concat(string strA, string strB)`| Nối hai chuỗi `strA` và `strB` thành một chuỗi mới.| Tương tự phép cộng chuỗi.|
| `IndexOf(char value)`| Trả về vị trí đầu tiên của ký tự `value` trong chuỗi.| Trả về -1 nếu không tìm thấy.|
| `Insert(int startIndex, string value)`| Trả về chuỗi mới có chèn thêm chuỗi `value` tại vị trí `startIndex`.||
| `String.IsNullOrEmpty(string value)`| Kiểm tra chuỗi `value` có phải là `null` hoặc rỗng hay không. Trả về `true` hoặc `false`.||
# String Builder

Lớp StringBuilder được sử dụng khi bạn cần thực hiện nhiều thao tác với chuỗi mà không muốn tạo nhiều đối tượng String mới. StringBuilder có thể thay đổi nội dung mà không tạo ra chuỗi mới.
```csharp
StringBuilder sb = new StringBuilder("Hello");

// Thêm chuỗi vào StringBuilder
sb.Append(" ");
sb.Append("John");
sb.Append("!");

Console.WriteLine(sb.ToString());  // Output: Hello John!
```
Lợi ích: StringBuilder hiệu quả hơn so với String khi cần nối, thay thế hoặc thao tác nhiều lần trên chuỗi, vì nó không tạo ra nhiều đối tượng mới trong bộ nhớ như String làm.
# Enum
### Khai báo Enum

```csharp
enum NgayTrongTuan
{
    ChuNhat,   // 0
    ThuHai,    // 1
    ThuBa,     // 2
    ThuTu,     // 3
    ThuNam,    // 4
    ThuSau,    // 5
    ThuBay     // 6
}
```
### Enum sang int
```
int ngaySo = (int)NgayTrongTuan.ThuHai; // Kết quả: 1
```