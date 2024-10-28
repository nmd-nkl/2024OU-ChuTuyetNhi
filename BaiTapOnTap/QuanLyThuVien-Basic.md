# Quản lý Thư Viện
### Mô tả:

    Sách trong thư viện (mã sách, tên sách, tác giả)
    Người mượn sách (tên, mã người mượn, thông tin liên lạc)
    Quản lý việc mượn và trả sách

### Code:
```csharp
using System;

public class Book
{
	public static int idCnt = 0;
	string BookId, Title, Author;
	bool IsBorrowed;
	public string GetBookID() { return BookId;}
	public string GetBookTitle() { return Title;}
	public void SetBookIsBorrowed(bool _isBorrowed) { IsBorrowed = _isBorrowed; }
	public bool GetStatusIsBorrowed() { return IsBorrowed; }

    public Book(string _Title, string _Author)
	{
		this.Title = _Title;
		this.Author = _Author;
		this.IsBorrowed = false;
		this.BookId = "B" + idCnt.ToString();
		idCnt++;
		Console.WriteLine($"Book added {this.Title} with ID: {this.BookId}");
	}

	public void DisplayInfo() {
		Console.WriteLine($"{this.BookId}: Name: {this.Title}, Author: {this.Author}, Status: Is Borrowed: {this.IsBorrowed}");
	}
}
```

```csharp
using System;

public class Member
{
	static int id = 0;
	string Name, MemberID, Contact;
	public string GetName() { return Name; }
    public string GetMemberID() { return MemberID; }
	public string GetContact() { return Contact; }
    public Member(string _name, string _contact)
	{
		this.Name = _name;
        this.Contact = _contact;
		MemberID = "M" + id.ToString();
		id++;
		Console.WriteLine($"Member Added {this.Name} with ID: {this.MemberID}");
	}
    public void DisplayInfo() {
        Console.WriteLine($"ID: {this.MemberID}, Name: {this.Name}, Contact: {this.Contact}");
    }
}
```

```csharp
using System;
using System.Net;

public class Library
{
	List<Book> books = new List<Book>();
	List<Member> members = new List<Member>();
	public void AddBook(Book book) => books.Add(book);
	public void AddMember(Member member) => members.Add(member);

	public void BorrowBook(string bookID, string memberID) {
        var book = books.Find(b => b.GetBookID() == bookID);
		if (book == null || book.GetStatusIsBorrowed()) {
			Console.WriteLine("No book available");
			return;
		}
		var member = members.Find(m => m.GetMemberID() == memberID);
		if(member==null){
			Console.WriteLine("Member not found");
			return;
		}

		book.SetBookIsBorrowed(true);
        Console.WriteLine($"{member.GetName()} borrowed {book.GetBookTitle()}");
    }
    public void ReturnBook(string bookId) {
        var book = books.Find(b => b.GetBookID() == bookId);
        if (book == null || !book.GetStatusIsBorrowed()) {
            Console.WriteLine("Invalid return");
            return;
        }

        book.SetBookIsBorrowed(false);
        Console.WriteLine($"{book.GetBookTitle()} returned");
    }
    public void DisplayAllBooks() {
        Console.WriteLine("Books:");
        foreach (var book in books)
            book.DisplayInfo();
    }
    public void DisplayAllMembers() {
        Console.WriteLine("Members:");
        foreach (var member in members)
            member.DisplayInfo();
    }
}
```

```csharp
namespace QuanLyThuVien {
    internal class Program {
    static void Main(string[] args) {
        Library library = new Library();

        Book book1 = new Book("C# Programming", "Author1");
        Book book2 = new Book("OOP Concepts", "Author2");
        library.AddBook(book1);
        library.AddBook(book2);

        Member member1 = new Member("Alice", "alice@gmail.com");
        library.AddMember(member1);

        library.BorrowBook("B0", "M0");
        library.ReturnBook("B0");

        library.DisplayAllBooks();
        library.DisplayAllMembers();
    }
}
}
```

### Output
```
Book added C# Programming with ID: B0
Book added OOP Concepts with ID: B1
Member Added Alice with ID: M0
Alice borrowed C# Programming
C# Programming returned
Books:
B0: Name: C# Programming, Author: Author1, Status: Is Borrowed: False
B1: Name: OOP Concepts, Author: Author2, Status: Is Borrowed: False
Members:
ID: M0, Name: Alice, Contact: alice@gmail.com
```
## KẾT LUẬN
1. Dùng hàm `get`, `set` để lấy dữ liệu `private`
2. Cách dùng `var` kết hợp với hàm `find` của List & `Lambda Expression`
3. Có thể đưa `class` vào các file khác nhau miễn là chung 1 project.
