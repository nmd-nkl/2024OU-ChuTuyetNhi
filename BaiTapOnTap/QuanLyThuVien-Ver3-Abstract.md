# Sửa đổi từ KeThuaVer1:
- Chuyển `book` thành `abstract class`
- Thay đổi hàm hiển thị `Ebook` và `Audio Book` vì giờ hàm này ở `book` là `abstract`
```csharp
using System;

public abstract class Book {
    private static int idCounter = 0;
    protected readonly string BookId, Title, Author;
    protected bool IsBorrowed;

    public string GetBookID() => BookId;
    public string GetBookTitle() => Title;
    public void SetBookIsBorrowed(bool _isBorrowed) => IsBorrowed = _isBorrowed;
    public bool GetStatusIsBorrowed() => IsBorrowed;

    public Book(string _Title, string _Author) {
        this.Title = _Title;
        this.Author = _Author;
        this.IsBorrowed = false;
        this.BookId = "B" + idCounter.ToString();
        idCounter++;
    }

    public abstract void DisplayInfo();
}
```
# Thay đổi trong `class` con
```csharp
public override void DisplayInfo() {
    //base.DisplayInfo(); Giờ là hàm abstract không có thân, không gọi được 
    Console.WriteLine("EBook:");
    Console.WriteLine($"{this.BookId}: Name: {this.Title}, Author: {this.Author}, Status: Is Borrowed: {this.IsBorrowed}");
    Console.WriteLine($"Ebook Type: {this.FileType}, MB: {this.FileSize}");
}
```
# Thay đổi trong hàm chính
xoá bỏ
```csharp
//Book
Book book1 = new Book("C# Programming", "Author1");
Book book2 = new Book("OOP Concepts", "Author2");
````
Đoạn trên sẽ bị lỗi vì giờ `Book` là `abstract`, là duy nhất, nên không thể tạo obj từ `Book`