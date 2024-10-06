# I. Git
 1. Trước khi làm kiểm tra nhán hiện tại 

 ```git
 git branch
 ```
 2. Checkout
 - Checkout sang branch của mình nế đã có branch
  ```git
 git checkout <branchName>
 ```

 - Checkout sang branch mới từ base branch (Nhánh chính)
  - Checkout sang branch của mình nế đã có branch
  ```git
 git checkout -b <newBranchName> <baseBranchName>
 ```
 
 3. Pull code từ base branch về
   ```git
 git pull origin <branchName>
 ```
 4. Sau khi làm xong push lên nhánh của mình tạo Pull Request để check trước khi merge vào nhánh chính
```git
 git push origin <branchName>
 ```

- HẠN CHẾ PUSH CODE LÊN MAIN
- HẠN CHẾ QUÊN CHECKOUT TRƯỚC KHI LÀM TRÁNH LỖI LÚC PUSH KHÓ SỬA

# II. Migration
- Open Nuget Manage Console 

## Add migration
```EF
Add-migration migrationName -Project BusinessObject -StartupProject VemsApi
```

## Run migration
```EF
Update-database -Project BusinessObject -StartupProject VemsApi
```