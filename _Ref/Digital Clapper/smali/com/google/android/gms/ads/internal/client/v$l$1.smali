.class Lcom/google/android/gms/ads/internal/client/v$l$1;
.super Ljava/lang/Thread;
.source "v$l.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/android/gms/ads/internal/client/v$l;->loadAndUpdateCache(Landroid/content/Context;Ljava/lang/String;I)Ljava/lang/String;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field private final synthetic val$contentKeyName:Ljava/lang/String;

.field private final synthetic val$md5:I

.field private final synthetic val$timeKeyName:Ljava/lang/String;

.field private final synthetic val$userKey:Ljava/lang/String;


# direct methods
.method constructor <init>(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 1
    iput p1, p0, Lcom/google/android/gms/ads/internal/client/v$l$1;->val$md5:I

    iput-object p2, p0, Lcom/google/android/gms/ads/internal/client/v$l$1;->val$userKey:Ljava/lang/String;

    iput-object p3, p0, Lcom/google/android/gms/ads/internal/client/v$l$1;->val$contentKeyName:Ljava/lang/String;

    iput-object p4, p0, Lcom/google/android/gms/ads/internal/client/v$l$1;->val$timeKeyName:Ljava/lang/String;

    .line 234
    invoke-direct {p0}, Ljava/lang/Thread;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 6

    .prologue
    .line 238
    :try_start_0
    iget v2, p0, Lcom/google/android/gms/ads/internal/client/v$l$1;->val$md5:I

    iget-object v3, p0, Lcom/google/android/gms/ads/internal/client/v$l$1;->val$userKey:Ljava/lang/String;

    invoke-static {v2, v3}, Lcom/google/android/gms/ads/internal/client/v$l;->access$0(ILjava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/google/android/gms/ads/internal/client/v$l;->access$1(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 239
    .local v1, "loadedContent":Ljava/lang/String;
    if-eqz v1, :cond_0

    .line 240
    invoke-virtual {v1}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v1

    .line 241
    const-string v2, ""

    invoke-virtual {v2, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_0

    .line 242
    invoke-static {v1}, Lcom/google/android/gms/ads/internal/client/v$l;->access$2(Ljava/lang/String;)V

    .line 243
    invoke-static {}, Lcom/google/android/gms/ads/internal/client/v$l;->access$3()Landroid/content/SharedPreferences;

    move-result-object v2

    invoke-interface {v2}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v0

    .line 244
    .local v0, "editor":Landroid/content/SharedPreferences$Editor;
    iget-object v2, p0, Lcom/google/android/gms/ads/internal/client/v$l$1;->val$contentKeyName:Ljava/lang/String;

    invoke-interface {v0, v2, v1}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    .line 245
    iget-object v2, p0, Lcom/google/android/gms/ads/internal/client/v$l$1;->val$timeKeyName:Ljava/lang/String;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-interface {v0, v2, v4, v5}, Landroid/content/SharedPreferences$Editor;->putLong(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;

    .line 246
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->commit()Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 251
    .end local v0    # "editor":Landroid/content/SharedPreferences$Editor;
    .end local v1    # "loadedContent":Ljava/lang/String;
    :cond_0
    :goto_0
    return-void

    .line 249
    :catch_0
    move-exception v2

    goto :goto_0
.end method
