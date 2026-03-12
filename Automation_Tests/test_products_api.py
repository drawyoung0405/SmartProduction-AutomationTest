import requests
import urllib3

urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

BASE_URL = "https://localhost:7002/api/products"

def test_get_all_products_success():
    """Test Case 1: Đọc dữ liệu Master Data."""
    response = requests.get(BASE_URL, verify=False)
    assert response.status_code == 200, f"Lỗi: Chạm API thất bại, status {response.status_code}"
    assert isinstance(response.json(), list), "Lỗi: API không trả về mảng JSON."

def test_create_product_success():
    """Test Case 2: Bơm dữ liệu chuẩn (Happy Case)."""
    payload = {
        "name": "Cảm Biến Áp Suất P1",
        "sku": "SENSOR-P1-001",
        "description": "Cảm biến lắp cho máy"
    }
    response = requests.post(BASE_URL, json=payload, verify=False)
    assert response.status_code == 201, f"Lỗi: Không thể tạo sản phẩm, status {response.status_code}"
    
    data = response.json()
    assert "id" in data, "Không thể sinh ra ID"
    assert data["sku"] == payload["sku"], "Dữ liệu bị lỗi!"

def test_create_product_missing_sku_should_fail():
    """Test Case 3: Negative Test - Thiếu dữ liệu."""
    payload = {
        "name": "Sản phẩm rác không có mã",
        "description": "Cố tình thiếu SKU"
    }
    response = requests.post(BASE_URL, json=payload, verify=False)
    assert response.status_code == 400, f"Lỗi QC: Lỗ hổng DTO! Hệ thống trả về {response.status_code}"