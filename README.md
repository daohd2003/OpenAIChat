# OpenRouter Chat Console App

Dự án này là một ứng dụng **Console Application** đơn giản được viết bằng **C# (.NET 8)**. Nó minh họa cách tích hợp và gọi API Chat Completion thông qua cổng **OpenRouter** (sử dụng model `deepseek/deepseek-chat-v3-0324:free`) bằng cách sử dụng `HttpClient` thuần để gửi yêu cầu HTTP và xử lý phản hồi JSON.

## 📖 Giới thiệu

Ứng dụng thực hiện các chức năng sau:
- Thiết lập kết nối HTTP đến API của OpenRouter.
- Cấu hình Headers xác thực (Bearer Token) và các Header bắt buộc của OpenRouter (`HTTP-Referer`, `X-Title`).
- Gửi một tin nhắn mẫu ("Xin chào, bạn có biết c# là gì không?") đến model DeepSeek.
- Phân tích chuỗi JSON trả về và hiển thị câu trả lời của AI ra màn hình Console.

## 🛠 Công nghệ sử dụng

| Thành phần | Công nghệ / Phiên bản |
| :--- | :--- |
| **Framework** | .NET 8.0 |
| **Ngôn ngữ** | C# |
| **API Provider** | [OpenRouter.ai](https://openrouter.ai) |
| **AI Model** | deepseek/deepseek-chat-v3-0324 |
| **JSON Handling** | System.Text.Json (9.0.5) |
| **Network** | System.Net.Http (HttpClient) |

## ⚙️ Cài đặt & Cấu hình

Để chạy dự án trên máy cục bộ, hãy làm theo các bước sau:

### 1. Yêu cầu tiên quyết
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Một API Key từ [OpenRouter](https://openrouter.ai/keys).

### 2. Clone dự án
```bash
git clone [https://github.com/your-username/daohd2003-openaichat.git](https://github.com/your-username/daohd2003-openaichat.git)
cd daohd2003-openaichat
```

### 3. Cấu hình API Key
⚠️ **Quan trọng:** Không bao giờ commit API Key thực lên source control công khai.

Mở file `Constants.cs` và thay thế giá trị của biến `OpenAIKey` bằng API Key của bạn:

```csharp
public static class Constants
{
    // Thay thế chuỗi bên dưới bằng Key thực của bạn từ OpenRouter
    public const string OpenAIKey = "sk-or-v1-your-real-api-key-here...";
}
```

### 4. Khôi phục các gói phụ thuộc
Chạy lệnh sau để tải các thư viện cần thiết (OpenAI, System.Text.Json...):
```bash
dotnet restore
```

## 🚀 Cách sử dụng (Usage)

Sau khi cấu hình xong, bạn có thể chạy ứng dụng bằng lệnh:

```bash
dotnet run
```

**Kết quả mong đợi:**
Màn hình console sẽ hiển thị câu trả lời từ AI giải thích về ngôn ngữ lập trình C#.

*Ví dụ:*
```text
C# là một ngôn ngữ lập trình hiện đại, đa năng, hướng đối tượng được phát triển bởi Microsoft...
```

## 📂 Cấu trúc thư mục

```text
daohd2003-openaichat/
├── Constants.cs        # Chứa các hằng số cấu hình (API Key)
├── Program.cs          # Entry point, xử lý logic gọi HTTP API
├── OpenAIChat.csproj   # File cấu hình dự án .NET
└── OpenAIChat.sln      # Solution file
```

---
