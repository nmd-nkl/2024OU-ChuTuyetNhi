# Sửa đổi từ Basic
- chuyển biến `private` của class **`book`** thành `protected` cho **Kế thừa**
- chuyển hàm của **`book`** thành `virtual` để `override` ở lớp con
- Thêm **Ebook** và **AudioBook** là kế thừa từ **`Book`**
- Cách rút gọn của `get` và `set`

### Class được thêm vào:
```csharp
public class AudioBook : Book
{
	public double DurationInSec { get; private set; } //rút gọn hơn so với Basic
	public string Narrator {  get; private set; }
	public AudioBook(string title, string author, double durationInSec, string narrator) : base(title, author) {
		this.DurationInSec = durationInSec;
		this.Narrator = narrator;
	}
    public override void DisplayInfo() {
        base.DisplayInfo();
		Console.WriteLine($"Audio Book: Narrator: {this.Narrator}, Duration: {this.DurationInSec} sec");
    }
}
```
```csharp
public class Ebook: Book
{
    public double FileSize { get; private set; }
    public string FileType { get; private set; }
    public Ebook(string title, string author, double fileSize, string fileType) : base(title, author)
	{
        this.FileSize = fileSize;
        this.FileType = fileType;
    }
    public override void DisplayInfo() {
        base.DisplayInfo();
        Console.WriteLine($"Ebook: {this.FileType}, MB: {this.FileSize}");
    }
}
```
### Thêm vào Program chính
```csharp
//Ebook
Ebook ebook1 = new Ebook("Call Me By Your Name", "Quen roi", 1314.00, "EPUB");
Console.WriteLine(ebook1.FileSize); //Ok: vì get là public
//ebook1.FileSize = 15.8; LỖI vì set là private
```