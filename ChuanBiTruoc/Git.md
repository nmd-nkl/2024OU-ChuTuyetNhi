# **Git** 

### Commands
**`git init`** Chuyển dự án thành một git repo

**`git status`**  Cho thấy trạng thái thay đổi

**`git clone <url>`** Sao chép một repo từ URL

**`git add <file>`** Thêm file vào vùng staging để chuẩn bị commit 

**`git add .`** Lưu lại tất cả file

**`git commit -m "message"`** Commit thay đổi với một thông điệp ngắn

**`git push`** Đẩy commit từ local repo lên remote repo

**`git pull`** Lấy và hợp nhất thay đổi từ remote repo về local

**`git status`** Kiểm tra trạng thái của các file trong repo

**`git log`** Xem lịch sử commit

#### Branch
**`git branch`** Kiểm tra branch

**`git branch {tên branch}`** Tạo branch

**`git checkout -b {tên branch}`** Truy cập branch khác

**`git merge {tên branch}`** Tổng hợp lại branch

**`git branch -d {tên branch}`** Xoá 1 branch

# new repo
```
echo "# temp" >> README.md
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/chunhi-Mou/temp.git
git push -u origin main
```