# Danh sách Phím Tắt trong Dự Án HuongViet

## 1. Form Quản Lý Vị Trí (FrmPosition)

### Phím tắt chính (KeyDown):
- **Ctrl + N**: Thêm vị trí mới
- **Ctrl + E**: Chỉnh sửa vị trí đã chọn
- **Ctrl + D**: Xóa vị trí đã chọn
- **Ctrl + S**: Lưu thông tin (khi đang ở chế độ chỉnh sửa)
- **Ctrl + F**: Di chuyển focus đến ô tìm kiếm
- **Ctrl + R**: Làm mới danh sách
- **Escape**: Hủy thao tác chỉnh sửa (khi đang ở chế độ chỉnh sửa)

### Phím tắt trong ô nhập liệu (KeyPress):
- **Enter** (trong ô tìm kiếm): Thực hiện tìm kiếm
- **Enter** (trong ô tên vị trí khi đang chỉnh sửa và nút Lưu được kích hoạt): Lưu thông tin

---

## 2. Form Quản Lý Phòng Ban (FrmDepartment)

### Phím tắt chính (KeyDown):
- **Ctrl + N**: Thêm phòng ban mới
- **Ctrl + E**: Chỉnh sửa phòng ban đã chọn
- **Ctrl + D**: Xóa phòng ban đã chọn
- **Ctrl + S**: Lưu thông tin (khi đang ở chế độ chỉnh sửa)
- **Ctrl + F**: Di chuyển focus đến ô tìm kiếm
- **Ctrl + R**: Làm mới danh sách
- **Escape**: Hủy thao tác chỉnh sửa (khi đang ở chế độ chỉnh sửa)

### Phím tắt trong ô nhập liệu (KeyPress):
- **Enter** (trong ô tìm kiếm): Thực hiện tìm kiếm
- **Enter** (trong ô tên phòng ban khi đang chỉnh sửa và nút Lưu được kích hoạt): Lưu thông tin

---

## 3. Form Bán Hàng (FrmPOS)

### Phím tắt chức năng:
- **F4**: Thanh toán đơn hàng (được hiển thị trên button "Thanh toán [F4]" nhưng **chưa được implement** trong code)

**Lưu ý**: Phím tắt F4 chỉ được hiển thị trên giao diện button, nhưng chưa có xử lý sự kiện KeyDown/KeyPress trong code. Cần click vào button để thanh toán.

---

## 4. Các Form Tìm Kiếm Chung

Các form sau đây đều hỗ trợ phím **Enter** trong ô tìm kiếm để thực hiện tìm kiếm:

### Form Quản Lý Món Ăn (FrmItem)
- **Enter** (trong ô tìm kiếm món ăn): Áp dụng bộ lọc/tìm kiếm

### Form Quản Lý Nhân Viên (FrmUser)
- **Enter** (trong ô tìm kiếm nhân viên): Thực hiện tìm kiếm

### Form Quản Lý Thể Loại (FrmCategory)
- **Enter** (trong ô tìm kiếm thể loại): Thực hiện tìm kiếm

### Form Quản Lý Đơn Vị Tính (FrmUnit)
- **Enter** (trong ô tìm kiếm đơn vị tính): Thực hiện tìm kiếm

### Form Quản Lý Dịch Vụ (FrmService)
- **Enter** (trong ô tìm kiếm dịch vụ): Áp dụng bộ lọc/tìm kiếm

### Form Quản Lý Vai Trò (FrmRole)
- **Enter** (trong ô tìm kiếm vai trò): Thực hiện tìm kiếm

---

## Tóm Tắt Phím Tắt Theo Chức Năng

### Phím tắt chung (CRUD):
- **Ctrl + N**: Thêm mới (New)
- **Ctrl + E**: Chỉnh sửa (Edit)
- **Ctrl + D**: Xóa (Delete)
- **Ctrl + S**: Lưu (Save)
- **Ctrl + F**: Tìm kiếm (Find)
- **Ctrl + R**: Làm mới (Refresh)
- **Escape**: Hủy (Cancel)

### Phím tắt chức năng đặc biệt:
- **F4**: Thanh toán (Payment) - Form POS (**chưa được implement**, chỉ hiển thị trên button)
- **Enter**: Thực hiện tìm kiếm hoặc lưu (tùy ngữ cảnh)

---

## Ghi Chú

1. **Phím tắt Ctrl + N, E, D, S, F, R** chỉ hoạt động trong các form:
   - FrmPosition (Quản lý vị trí)
   - FrmDepartment (Quản lý phòng ban)

2. **Phím Escape** chỉ hoạt động khi form đang ở chế độ chỉnh sửa và nút Hủy được kích hoạt.

3. **Phím Enter** trong ô tìm kiếm hoạt động trên tất cả các form có chức năng tìm kiếm.

4. **Phím Enter** trong ô nhập liệu (tên vị trí, tên phòng ban) chỉ hoạt động khi:
   - Form đang ở chế độ chỉnh sửa
   - Nút Lưu được kích hoạt (enabled)

5. Form **FrmReport** (Báo cáo) không có phím tắt được định nghĩa trong code hiện tại.

6. **F4 trong FrmPOS**: Mặc dù được hiển thị trên button, phím tắt này chưa được implement trong code. Người dùng cần click vào button để thanh toán.

---

## File Nguồn Tham Khảo

- `HuongViet.GUI/HuongViet.GUI/FrmPosition.cs` (dòng 490-522)
- `HuongViet.GUI/HuongViet.GUI/FrmDepartment.cs` (dòng 465-496)
- `HuongViet.GUI/HuongViet.GUI/FrmPOS.Designer.cs` (dòng 283)
- Các file form tìm kiếm: `FrmItem.cs`, `FrmUser.cs`, `FrmCategory.cs`, `FrmUnit.cs`, `FrmService.cs`, `FrmRole.cs`

