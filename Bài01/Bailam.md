Dưới đây là phần trả lời lý thuyết được trình bày dạng văn bản/danh sách chi tiết:

Câu 1: Sự khác nhau giữa Value Types và Reference Types về cơ chế lưu trữ vùng nhớ (Stack vs Heap)
Vùng nhớ lưu trữ:

Value Types: Dữ liệu thực sự được lưu trực tiếp trên bộ nhớ Stack (hoặc nằm trong Heap nếu nó là một thuộc tính/trường của một Reference Type).

Reference Types: Dữ liệu/Đối tượng thực sự được lưu trên bộ nhớ Heap. Biến nằm trên Stack chỉ lưu địa chỉ con trỏ (tham chiếu) trỏ đến vùng nhớ Heap đó.

Kiểu dữ liệu tiêu biểu:

Value Types: int, float, double, bool, char, struct, enum, ...

Reference Types: string, object, class, interface, array, delegate, ...

Hành vi khi gán/sao chép:

Value Types: Tạo ra một bản sao độc lập của giá trị. Thay đổi biến mới không làm ảnh hưởng đến biến cũ.

Reference Types: Sao chép địa chỉ tham chiếu. Cả hai biến cùng trỏ về một vùng nhớ trên Heap; thay đổi qua biến này sẽ ảnh hưởng đến biến kia.

Quản lý bộ nhớ:

Value Types: Tự động giải phóng khi biến ra khỏi phạm vi (scope) thực thi.

Reference Types: Được quản lý và thu gom tự động bởi trình dọn rác Garbage Collector (GC).

Câu 2: So sánh Init-only Properties (init) và set thông thường. Trường hợp sử dụng thực tế
Sự khác nhau:

set (Mutating): Cho phép thay đổi giá trị của thuộc tính bất kỳ lúc nào trong suốt vòng đời của đối tượng.

init (Immutable): Chỉ cho phép gán giá trị một lần duy nhất lúc khởi tạo đối tượng (qua Constructor hoặc Object Initializer { Property = value }). Sau khi quá trình khởi tạo hoàn tất, thuộc tính trở thành Read-only và không thể sửa đổi.

Trường hợp sử dụng thực tế:

Sử dụng init khi thiết kế các đối tượng bất biến (Immutable Objects) hoặc các lớp DTO (Data Transfer Object) chuyên dùng để truyền dữ liệu giữa các tầng trong ứng dụng, giúp đảm bảo dữ liệu không bị vô tình sửa đổi sai quy cách ở nơi khác sau khi đã khởi tạo.

Câu 3: Phân biệt phương thức virtual ở lớp cha và override ở lớp con
virtual (Lớp cha):

Khai báo một phương thức ở lớp cha rằng nó cho phép các lớp con có thể ghi đè (thay đổi) hành vi của phương thức này nếu cần.

Phương thức virtual bắt buộc phải có phần thân (body) để cung cấp triển khai mặc định.

override (Lớp con):

Được sử dụng ở lớp con để chính thức ghi đè và cung cấp một triển khai mới cho phương thức virtual của lớp cha.

Khi gọi phương thức qua con trỏ lớp cha trỏ đến đối tượng lớp con, cơ chế đa hình sẽ chạy mã nguồn trong hàm override của lớp con thay vì mã mặc định của lớp cha.

Câu 4: Tại sao thành phần static không thể truy xuất thông qua thể hiện (Object Instance)?
Thành phần static thuộc về cấp độ Lớp (Class level) chứ không thuộc về từng thể hiện đối tượng (Instance level) cụ thể được tạo ra bằng toán tử new.

Về mặt bộ nhớ: Các thành phần static chỉ được khởi tạo một lần duy nhất trong vùng nhớ Type Metadata/Static Area khi Lớp được nạp vào chương trình và chia sẻ chung cho toàn bộ ứng dụng, thay vì nhân bản trên bộ nhớ Heap của từng đối tượng instance.

Về mặt ngữ nghĩa & thiết kế ngôn ngữ C#: Trình biên dịch C# cố ý cấm truy xuất static qua instance (ví dụ: obj.StaticMethod()) để tránh gây hiểu nhầm logic rằng hành vi/dữ liệu đó thay đổi tùy theo từng đối tượng riêng biệt. Do đó, bạn phải truy cập trực tiếp thông qua tên Lớp (ví dụ: ClassName.StaticMethod()).
