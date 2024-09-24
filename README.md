## 功能介紹

- **鄉鎮市公所名稱查詢（來自新竹縣政府 Open Data）**
  - 透過 Web API 介接，取得鄉鎮市公所名稱資料。

---

## 資料夾結構說明

- **0.Template_NET_Framework.Common**  
  - 共用模組與工具，負責提供基礎功能和通用邏輯。

- **1.Template_NET_Framework.Application**  
  - 應用層，負責業務邏輯的調用及應用邏輯的實現。

- **2.Template_NET_Framework.Services**  
  - 服務層，負責具體的業務邏輯實現及處理。

- **3.Template_NET_Framework.Repositories**  
  - 資料存取層，專門負責與資料庫或其他數據源的互動。

---

## 專案技術與工具

- **ASP.NET Web 應用程式 (.NET Framework 4.8)**  
  - 基於 Web API 架構，提供 RESTful 服務。

- **AutoMapper**  
  - 自動化物件模型映射工具，用於簡化資料傳輸對象（DTO）與實體模型之間的轉換。

- **HttpClientFactory**  
  - 用於管理與重用 `HttpClient` 實例，提升 HTTP 請求效能並優化資源管理。

- **Unity**  
  - 依賴注入 (DI) 工具，提供靈活的依賴管理與注入機制。

- **nLog**  
  - 日誌管理工具，負責記錄與管理系統運行時的 Log 資訊，便於除錯與監控。

- **ActionFilterAttribute**  
  - 自訂的 `TimeLogAttribute`，用來計算並記錄每個 Web API 請求的總耗時，便於效能監控和分析。

- **NUnit**  
  - 單元測試框架，用於撰寫與執行自動化測試，確保系統的穩定性與可靠性。

- **FluentAssertions**  
  - 提升單元測試可讀性與可維護性的工具，使測試語法更簡潔明確。

- **NSubstitute**  
  - Mocking 框架，用於單元測試中模擬依賴項，以進行隔離測試，提升測試精度。
  - test
