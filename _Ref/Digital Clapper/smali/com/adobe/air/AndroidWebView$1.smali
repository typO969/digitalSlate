.class Lcom/adobe/air/AndroidWebView$1;
.super Landroid/webkit/WebChromeClient;
.source "AndroidWebView.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/adobe/air/AndroidWebView;-><init>()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field private mUploadMessage:Landroid/webkit/ValueCallback;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Landroid/webkit/ValueCallback",
            "<",
            "Landroid/net/Uri;",
            ">;"
        }
    .end annotation
.end field

.field final synthetic this$0:Lcom/adobe/air/AndroidWebView;


# direct methods
.method constructor <init>(Lcom/adobe/air/AndroidWebView;)V
    .locals 0

    .prologue
    .line 404
    iput-object p1, p0, Lcom/adobe/air/AndroidWebView$1;->this$0:Lcom/adobe/air/AndroidWebView;

    invoke-direct {p0}, Landroid/webkit/WebChromeClient;-><init>()V

    return-void
.end method

.method static synthetic access$700(Lcom/adobe/air/AndroidWebView$1;)Landroid/webkit/ValueCallback;
    .locals 1

    .prologue
    .line 404
    iget-object v0, p0, Lcom/adobe/air/AndroidWebView$1;->mUploadMessage:Landroid/webkit/ValueCallback;

    return-object v0
.end method

.method static synthetic access$702(Lcom/adobe/air/AndroidWebView$1;Landroid/webkit/ValueCallback;)Landroid/webkit/ValueCallback;
    .locals 0

    .prologue
    .line 404
    iput-object p1, p0, Lcom/adobe/air/AndroidWebView$1;->mUploadMessage:Landroid/webkit/ValueCallback;

    return-object p1
.end method


# virtual methods
.method public onHideCustomView()V
    .locals 1

    .prologue
    .line 418
    iget-object v0, p0, Lcom/adobe/air/AndroidWebView$1;->this$0:Lcom/adobe/air/AndroidWebView;

    invoke-static {v0}, Lcom/adobe/air/AndroidWebView;->access$600(Lcom/adobe/air/AndroidWebView;)Lcom/adobe/air/AndroidWebView$WebViewCustomView;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 419
    iget-object v0, p0, Lcom/adobe/air/AndroidWebView$1;->this$0:Lcom/adobe/air/AndroidWebView;

    invoke-static {v0}, Lcom/adobe/air/AndroidWebView;->access$600(Lcom/adobe/air/AndroidWebView;)Lcom/adobe/air/AndroidWebView$WebViewCustomView;

    move-result-object v0

    invoke-virtual {v0}, Lcom/adobe/air/AndroidWebView$WebViewCustomView;->onHideCustomView()V

    .line 420
    :cond_0
    return-void
.end method

.method public onShowCustomView(Landroid/view/View;Landroid/webkit/WebChromeClient$CustomViewCallback;)V
    .locals 3

    .prologue
    .line 410
    iget-object v0, p0, Lcom/adobe/air/AndroidWebView$1;->this$0:Lcom/adobe/air/AndroidWebView;

    invoke-static {v0}, Lcom/adobe/air/AndroidWebView;->access$600(Lcom/adobe/air/AndroidWebView;)Lcom/adobe/air/AndroidWebView$WebViewCustomView;

    move-result-object v0

    if-nez v0, :cond_0

    .line 411
    iget-object v0, p0, Lcom/adobe/air/AndroidWebView$1;->this$0:Lcom/adobe/air/AndroidWebView;

    new-instance v1, Lcom/adobe/air/AndroidWebView$WebViewCustomView;

    iget-object v2, p0, Lcom/adobe/air/AndroidWebView$1;->this$0:Lcom/adobe/air/AndroidWebView;

    invoke-direct {v1, v2}, Lcom/adobe/air/AndroidWebView$WebViewCustomView;-><init>(Lcom/adobe/air/AndroidWebView;)V

    invoke-static {v0, v1}, Lcom/adobe/air/AndroidWebView;->access$602(Lcom/adobe/air/AndroidWebView;Lcom/adobe/air/AndroidWebView$WebViewCustomView;)Lcom/adobe/air/AndroidWebView$WebViewCustomView;

    .line 413
    :cond_0
    iget-object v0, p0, Lcom/adobe/air/AndroidWebView$1;->this$0:Lcom/adobe/air/AndroidWebView;

    invoke-static {v0}, Lcom/adobe/air/AndroidWebView;->access$600(Lcom/adobe/air/AndroidWebView;)Lcom/adobe/air/AndroidWebView$WebViewCustomView;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/adobe/air/AndroidWebView$WebViewCustomView;->onShowCustomView(Landroid/view/View;Landroid/webkit/WebChromeClient$CustomViewCallback;)V

    .line 414
    return-void
.end method

.method public openFileChooser(Landroid/webkit/ValueCallback;)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/webkit/ValueCallback",
            "<",
            "Landroid/net/Uri;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 424
    iget-object v0, p0, Lcom/adobe/air/AndroidWebView$1;->mUploadMessage:Landroid/webkit/ValueCallback;

    if-eqz v0, :cond_0

    .line 461
    :goto_0
    return-void

    .line 427
    :cond_0
    iput-object p1, p0, Lcom/adobe/air/AndroidWebView$1;->mUploadMessage:Landroid/webkit/ValueCallback;

    .line 429
    invoke-static {}, Lcom/adobe/air/AndroidActivityWrapper;->GetAndroidActivityWrapper()Lcom/adobe/air/AndroidActivityWrapper;

    move-result-object v0

    .line 431
    new-instance v1, Lcom/adobe/air/AndroidWebView$1$1;

    invoke-direct {v1, p0, v0}, Lcom/adobe/air/AndroidWebView$1$1;-><init>(Lcom/adobe/air/AndroidWebView$1;Lcom/adobe/air/AndroidActivityWrapper;)V

    .line 452
    invoke-virtual {v0, v1}, Lcom/adobe/air/AndroidActivityWrapper;->addActivityResultListener(Lcom/adobe/air/AndroidActivityWrapper$ActivityResultCallback;)V

    .line 454
    new-instance v1, Landroid/content/Intent;

    const-string v2, "android.intent.action.GET_CONTENT"

    invoke-direct {v1, v2}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 455
    const-string v2, "android.intent.category.OPENABLE"

    invoke-virtual {v1, v2}, Landroid/content/Intent;->addCategory(Ljava/lang/String;)Landroid/content/Intent;

    .line 456
    const-string v2, "*/*"

    invoke-virtual {v1, v2}, Landroid/content/Intent;->setType(Ljava/lang/String;)Landroid/content/Intent;

    .line 458
    invoke-virtual {v0}, Lcom/adobe/air/AndroidActivityWrapper;->getActivity()Landroid/app/Activity;

    move-result-object v0

    .line 459
    const-string v2, ""

    invoke-static {v1, v2}, Landroid/content/Intent;->createChooser(Landroid/content/Intent;Ljava/lang/CharSequence;)Landroid/content/Intent;

    move-result-object v1

    const/4 v2, 0x5

    invoke-virtual {v0, v1, v2}, Landroid/app/Activity;->startActivityForResult(Landroid/content/Intent;I)V

    goto :goto_0
.end method
