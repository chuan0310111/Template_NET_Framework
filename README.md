## 功能介紹

- **鄉鎮市公所名稱取得（來自新竹縣政府 Open Data）**
  - 透過快取機制取得鄉鎮市公所名稱，提升效能。
  - 支援強制重設快取，並重新獲取最新資料。

---

## 資料夾結構說明

- **0.Template_NET_Framework.Common**  
  - 共用模組與工具，提供基礎功能。

- **1.Template_NET_Framework.Application**  
  - 應用層，負責處理業務邏輯及應用邏輯的調用。

- **2.Template_NET_Framework.Services**  
  - 服務層，負責具體的業務邏輯實現和處理。

- **3.Template_NET_Framework.Repositories**  
  - 資料存取層，負責與資料庫或其他數據源的互動。

---

## 專案技術與工具

- **ASP.NET Web 應用程式 (.NET Framework 4.8)**  
  - 使用 Web API 架構來提供 RESTful 服務。

- **AutoMapper**  
  - 自動化物件模型的映射，簡化 DTO 與實體模型之間的轉換過程。

- **HttpClientFactory**  
  - 用於管理和重用 `HttpClient` 實例，提升 HTTP 請求效能，並有效管理資源。

- **Unity**  
  - 依賴注入 (DI) 工具，提供靈活的組件注入和管理。

- **nLog**  
  - 日誌管理工具，用於記錄和管理系統運行時的 Log，便於排錯和監控。

- **FluentAssertions**  
  - 提升單元測試的可讀性與可維護性，讓測試表達式更直觀易懂。

- **NSubstitute**  
  - 單元測試中的 Mocking 框架，用於模擬依賴項目以進行隔離測試。

- **ActionFilterAttribute**  
  - 自訂屬性 `TimeLogAttribute`，用來建立計時器以計算每個 Web API 請求的總耗時，方便效能監控。
