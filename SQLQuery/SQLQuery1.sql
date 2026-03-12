SELECT * FROM Products;

-- (Tư duy QA) Tìm chính xác sản phẩm vừa được API POST tạo ra để đối chiếu
SELECT Id, Name, SKU, CreatedDate 
FROM Products 
WHERE SKU = 'BOARD-X1-1024';

-- Đếm xem hiện tại xưởng đang có bao nhiêu lệnh sản xuất
SELECT COUNT(*) AS TotalOrders FROM ProductionOrders;

INSERT INTO Products (Name, SKU, Description, CreatedDate)
VALUES 
('Chip Bán Dẫn A1', 'SEMICON-A1-001', 'Chip xử lý trung tâm', GETUTCDATE()),
('Mạch Điều Khiển B2', 'BOARD-B2-002', 'Bo mạch tự động hóa', GETUTCDATE());

SELECT Id, Name FROM Products;

--ProductionOrders--
INSERT INTO ProductionOrders (OrderNumber, ProductId, Quantity, Status, OrderDate, CompletionDate)
VALUES 
-- Kịch bản 1: Lệnh vừa tạo, đang chờ xử lý (Pending = 0), chưa có ngày hoàn thành (NULL)
('PO-20260312-001', 6, 5000, 0, GETUTCDATE(), NULL),

-- Kịch bản 2: Lệnh đang chạy trên dây chuyền (InProgress = 1), chưa có ngày hoàn thành (NULL)
('PO-20260312-002', 7, 2000, 1, GETUTCDATE(), NULL),

-- Kịch bản 3: Lệnh đã sản xuất xong (Completed = 2), BẮT BUỘC phải có ngày hoàn thành
('PO-20260312-003', 6, 1000, 2, GETUTCDATE(), GETUTCDATE()),

-- Kịch bản 4: Lệnh bị lỗi/hủy (Defective = 3), dây chuyền dừng lại
('PO-20260312-004', 7, 300, 3, GETUTCDATE(), NULL);