# `Collections C# `
Các lớp hỗ trợ lưu trữ, quản lý và thao tác với các đối tượng một cách có thứ tự.

Các lớp này nằm trong **`namespace System.Collections.`**
```csharp
using System.Collections;
```
### Khi nào nên dùng?
- **Mảng** dành cho đối tượng **Strongly-typed** (kiểu dữ liệu không bị thay đổi 1 cách đột ngột, tường minh)
- **Collections** cung cấp linh hoạt hơn, truy xuất nhanh chóng
---
**MỤC LỤC**
1. [ArrayList](#arraylist)
2. [HashTable](#hashtable)
3. [SortedList](#sortedlist)
4. [Stack](#stack)
5. [Queue](#queue)
6. [Generic](#generic)
7. [List](#list)
8. [Dictionary](#dictionary)
9. [So sánh HashTable và Dictionary](#so-sánh-hashtable-và-dictionary)
---
# ArrayList 
- Quản lý một danh sách các đối tượng theo kiểu mảng
- Có thể thêm hoặc xoá các phần tử một cách linh hoạt và có thể tự điều chỉnh kích cỡ một cách tự động.
## Khởi tạo
```csharp
// khởi tạo 1 ArrayList rỗng
ArrayList MyArray = new ArrayList(); 
```
```csharp
// khởi tạo 1 ArrayList và chỉ định Capacity ban đầu là 5
ArrayList MyArray2 = new ArrayList(5); 
```
```csharp
//Sao chép toàn độ phần tử trong MyArray2 vào MyArray3.
 ArrayList MyArray3 = new ArrayList(MyArray2);
```
## Phương thức
### Chèn phần tử
```csharp
ArrayList arrayList = new ArrayList();
arrayList.Add("Hello");
arrayList.Add(10);
arrayList.Add(3.14);
```
### Count & Capacity
```csharp
Console.WriteLine("Number of elements: " + myList.Count); 
Console.WriteLine("Curr capacity: " + myList.Capacity); 
```
### Remove
```csharp
MyArray.Remove('G'); //xoá phần tử 'G'
MyArray.RemoveAt(8); //xoá phần tử tại idx 8
MyArray.RemoveRange(1, 3); //xoá phần tử idx 1 đến 3
MyArray.Clear(); //xoá tất cả phần tử
MyArray.Contains(300) //ktra xem List có 300 hay không
```
### Sort
```csharp
MyArray.Sort(); //Quick Sort tăng dần
```
## Lưu ý:
1. `ArrayList` có thể chứa nhiều kiểu dữ liệu khác nhau, nhưng nên tránh để đảm bảo tính nhất quán.
2. Khi sử dụng `Sort()` hoặc `BinarySearch()`, các phần tử phải có cùng kiểu dữ liệu.
---
# HashTable
- Lưu trữ các cặp key-value (khóa-giá trị), cho phép truy cập nhanh chóng dựa trên key
- Key phải là duy nhất, không thể là **Null**
- Value có thể là **Null** và bị trùng
## Khởi tạo
```csharp
// khởi tạo 1 Hashtable rỗng
Hashtable MyHash = new Hashtable(); 
// khởi tạo 1 Hashtable và chỉ định Capacity ban đầu là 5
Hashtable MyHash2 = new Hashtable(5); 
//Sao chép toàn độ phần tử trong MyHash2 vào MyHash3.
 Hashtable MyHash3 = new Hashtable(MyHash2);
```
## Truy cập
```csharp
Console.WriteLine("Hashtable elements:");
foreach (DictionaryEntry entry in MyHash) {
    Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
}
// Truy cập giá trị theo khóa
Console.WriteLine($"Value for key 'B': {MyHash["B"]}");
```
## Lưu ý:
- Nếu lấy giá trị 1 phần tử trong Hashtable với Key không tồn tại thì sẽ ra giá trị null và không báo lỗi.

- `HashTable` là non-generic collection, nên khi lấy giá trị cần phải type cast
```csharp
var cities = new Hashtable(){
	{"UK", "London, Manchester, Birmingham"},
	{"USA", "Chicago, New York, Washington"}
};
string citiesOfUK = (string) cities["UK"]; //cast to string
string citiesOfUSA = (string) cities["USA"]; //cast to string
cities.Remove("UK"); // removes UK 
```
---
# SortedList
- Kết hợp giữa ArrayList và HashTable
- Nó lưu trữ các cặp key-value, nhưng các phần tử được sắp xếp theo thứ tự tăng dần của khóa
- Cho phép bạn truy cập các phần tử thông qua khóa và có hiệu suất tốt trong việc truy cập dữ liệu
## Khởi tạo
```csharp
// khởi tạo 1 SortedList rỗng
SortedList MySL = new SortedList(); 
// khởi tạo 1 SortedList và chỉ định Capacity ban đầu là 5
SortedList MySL2 = new SortedList(5); 
SortedList MySL3 = new SortedList(MySL2);
```
## Truy cập
```csharp
Console.WriteLine("SortedList elements:");
foreach (DictionaryEntry entry in sortedList) {
    Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
}
// Truy cập giá trị theo khóa
Console.WriteLine($"Value for key 'A': {sortedList["A"]}");
```
# Stack
**Nguyên tắc LIFO (Last In, First Out)**
## Khai báo
```csharp
Stack<int> stack = new Stack<int>();
// Thêm phần tử vào stack
stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine("Stack elements:");
foreach (var item in stack)
{
    Console.WriteLine(item);
}
// Lấy phần tử ra khỏi stack
Console.WriteLine($"Pop: {stack.Pop()}"); // Lấy ra 3
Console.WriteLine($"Peek: {stack.Peek()}"); // Xem phần tử trên cùng (2)
```
# Queue
**Nguyên tắc FIFO (First In, First Out)**
```csharp
Queue<string> queue = new Queue<string>();   
// Thêm phần tử vào queue
queue.Enqueue("Apple");
queue.Enqueue("Banana");
queue.Enqueue("Cherry");
Console.WriteLine("Queue elements:");
foreach (var item in queue)
{
    Console.WriteLine(item);
}
// Lấy phần tử ra khỏi queue
Console.WriteLine($"Dequeue: {queue.Dequeue()}"); // Lấy ra Apple
Console.WriteLine($"Peek: {queue.Peek()}"); // Xem phần tử đầu tiên (Banana)
```
----
# Generic
Generic cho phép định nghĩa các lớp, phương thức, và cấu trúc mà không cần chỉ định kiểu dữ liệu cụ thể. 

Điều này giúp tăng tính linh hoạt và tái sử dụng mã.
```csharp
public static void Swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}
```
```csharp
int a = 5, b = 7;
double c = 1.2, d = 5.6;
Swap<int>(ref a, ref b);
Swap<double>(ref c, ref d);
```
```csharp
// Khởi tạo 1 mảng số nguyên kiểu int có 5 phần tử
MyGeneric<int> MyG = new MyGeneric<int>(5);
```
# List
```csharp
using System.Collections.Generic;
```
List<T> là một **`Generic Collections`**  có khả năng thay đổi kích thước, tương tự như ArrayList, nhưng chỉ có thể chứa các đối tượng cùng kiểu T. 

Điều này giúp bảo vệ dữ liệu và cải thiện hiệu suất.
```csharp
// khởi tạo 1 List các số nguyên rỗng
List<int> MyList = new List<int>(); 
```
```csharp
List<string> list = new List<string> { "Apple", "Banana", "Cherry" };
Console.WriteLine("List elements:");
foreach (var item in list)
{
    Console.WriteLine(item);
}
// Thêm phần tử
list.Add("Date");
// Xóa phần tử
list.Remove("Banana");
Console.WriteLine("After modification:");
foreach (var item in list)
{
    Console.WriteLine(item);
}
```
# Dictionary
- Lưu trữ các cặp key-value, cho phép truy cập nhanh chóng theo khóa. 
- Các khóa là duy nhất và không thể trùng lặp.
```csharp
using System.Collections.Generic;
```
```csharp
 Dictionary<string, int> dictionary = new Dictionary<string, int>
{
    { "Apple", 1 },
    { "Banana", 2 },
    { "Cherry", 3 }
};

Console.WriteLine("Dictionary elements:");
foreach (var kvp in dictionary)
{
    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
}
// Truy cập giá trị theo khóa
Console.WriteLine($"Value for key 'Banana': {dictionary["Banana"]}");
```
# So Sánh HashTable và Dictionary
| **HASHTABLE**         | **DICTIONARY**                 |
|-----------------------------------------------------------|----------------------------------------------------------|
| Threadsafe - Hỗ trợ multi-threading không đụng độ tài nguyên | Không hỗ trợ.                                             |
| Cặp Key - Value lưu kiểu object                    | Phải xác định cụ thể kiểu dữ liệu của cặp Key - Value     |
| Truy xuất phần tử không tồn tại                      | Truy xuất phần tử không tồn tại trong `Hashtable` sẽ không báo lỗi, suy ra trả về `null`. |
| Truy xuất phần tử không tồn tại                      | Truy xuất phần tử không tồn tại trong `Dictionary` sẽ báo lỗi. |
| Hiệu quả cho dữ liệu lớn                              | Không hiệu quả cho dữ liệu lớn                            |
| Các phần tử được sắp xếp lại mỗi khi thêm hoặc xóa    | Các phần tử nằm theo thứ tự được thêm vào.                |
| Tìm kiếm nhanh hơn                             | Tìm kiếm chậm hơn.                                       |