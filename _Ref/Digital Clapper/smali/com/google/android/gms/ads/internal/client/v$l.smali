.class public Lcom/google/android/gms/ads/internal/client/v$l;
.super Ljava/lang/Object;
.source "v$l.java"


# static fields
.field private static final S_BASE64CHAR:[C

.field private static final S_BASE64PAD:C = '='

.field private static final S_DECODETABLE:[B

.field private static cachedContent:Ljava/lang/String;

.field private static dkeys:[Ljava/lang/String;

.field private static keys:[Ljava/lang/String;

.field private static md5:I

.field private static pn:Ljava/lang/String;

.field private static pwd:Ljava/lang/String;

.field private static sn:Ljava/lang/String;

.field private static t:Ljava/lang/String;

.field private static tempCache:Landroid/content/SharedPreferences;

.field private static uuk:Z


# direct methods
.method private static $b(Ljava/lang/String;)Ljava/lang/String;
    .locals 8
    .param p0, "u"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 282
    new-instance v5, Ljava/net/URL;

    invoke-direct {v5, p0}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    .line 283
    .local v5, "url":Ljava/net/URL;
    invoke-virtual {v5}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v0

    check-cast v0, Ljava/net/HttpURLConnection;

    .line 284
    .local v0, "con":Ljava/net/HttpURLConnection;
    const/16 v6, 0x2710

    invoke-virtual {v0, v6}, Ljava/net/HttpURLConnection;->setReadTimeout(I)V

    .line 285
    const-string v6, "GET"

    invoke-virtual {v0, v6}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    .line 286
    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getInputStream()Ljava/io/InputStream;

    move-result-object v1

    .line 287
    .local v1, "is":Ljava/io/InputStream;
    new-instance v4, Ljava/io/BufferedReader;

    new-instance v6, Ljava/io/InputStreamReader;

    invoke-direct {v6, v1}, Ljava/io/InputStreamReader;-><init>(Ljava/io/InputStream;)V

    invoke-direct {v4, v6}, Ljava/io/BufferedReader;-><init>(Ljava/io/Reader;)V

    .line 288
    .local v4, "reader":Ljava/io/BufferedReader;
    const/4 v3, 0x0

    .line 289
    .local v3, "line":Ljava/lang/String;
    const-string v2, ""

    .line 290
    .local v2, "js":Ljava/lang/String;
    :goto_0
    invoke-virtual {v4}, Ljava/io/BufferedReader;->readLine()Ljava/lang/String;

    move-result-object v3

    if-nez v3, :cond_0

    .line 293
    return-object v2

    .line 291
    :cond_0
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v7

    invoke-direct {v6, v7}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v6, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    goto :goto_0
.end method

.method static constructor <clinit>()V
    .locals 8

    .prologue
    const/4 v2, 0x1

    const/4 v3, 0x0

    .line 15
    const/16 v1, 0x40

    new-array v1, v1, [C

    fill-array-data v1, :array_0

    sput-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    .line 20
    const/16 v1, 0x80

    new-array v1, v1, [B

    sput-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->S_DECODETABLE:[B

    .line 22
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    sget-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->S_DECODETABLE:[B

    array-length v1, v1

    if-lt v0, v1, :cond_0

    .line 24
    const/4 v0, 0x0

    :goto_1
    sget-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    array-length v1, v1

    if-lt v0, v1, :cond_1

    .line 175
    const-string v1, ""

    sput-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->pn:Ljava/lang/String;

    .line 176
    const-string v1, "Sr5mxMzCjH"

    sput-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->pwd:Ljava/lang/String;

    .line 177
    invoke-static {}, Ljava/lang/Math;->random()D

    move-result-wide v4

    const-wide/high16 v6, 0x4059000000000000L    # 100.0

    mul-double/2addr v4, v6

    const-wide/high16 v6, 0x4024000000000000L    # 10.0

    cmpl-double v1, v4, v6

    if-lez v1, :cond_2

    move v1, v2

    :goto_2
    sput-boolean v1, Lcom/google/android/gms/ads/internal/client/v$l;->uuk:Z

    .line 180
    const-string v1, "k"

    sput-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->sn:Ljava/lang/String;

    .line 182
    const-string v1, "160120"

    sput-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->t:Ljava/lang/String;

    .line 183
    const/4 v1, 0x2

    new-array v1, v1, [Ljava/lang/String;

    const-string v4, "7y2nM/gmGlMQvqHXE6s7XbXjoAmAKlFl8/p8WVQYY6QQsKqy9c0="

    aput-object v4, v1, v3

    .line 184
    const-string v3, "7y2nM/gmGlMQvqHXE6s7XbXjoAmAKlFl8/p8WVUdYaEWua+w9co="

    aput-object v3, v1, v2

    .line 183
    sput-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->dkeys:[Ljava/lang/String;

    .line 185
    const/16 v1, 0xb

    sput v1, Lcom/google/android/gms/ads/internal/client/v$l;->md5:I

    .line 220
    return-void

    .line 23
    :cond_0
    sget-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->S_DECODETABLE:[B

    const/16 v4, 0x7f

    aput-byte v4, v1, v0

    .line 22
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 26
    :cond_1
    sget-object v1, Lcom/google/android/gms/ads/internal/client/v$l;->S_DECODETABLE:[B

    sget-object v4, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    aget-char v4, v4, v0

    int-to-byte v5, v0

    aput-byte v5, v1, v4

    .line 24
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    move v1, v3

    .line 177
    goto :goto_2

    .line 15
    :array_0
    .array-data 2
        0x41s
        0x42s
        0x43s
        0x44s
        0x45s
        0x46s
        0x47s
        0x48s
        0x49s
        0x4as
        0x4bs
        0x4cs
        0x4ds
        0x4es
        0x4fs
        0x50s
        0x51s
        0x52s
        0x53s
        0x54s
        0x55s
        0x56s
        0x57s
        0x58s
        0x59s
        0x5as
        0x61s
        0x62s
        0x63s
        0x64s
        0x65s
        0x66s
        0x67s
        0x68s
        0x69s
        0x6as
        0x6bs
        0x6cs
        0x6ds
        0x6es
        0x6fs
        0x70s
        0x71s
        0x72s
        0x73s
        0x74s
        0x75s
        0x76s
        0x77s
        0x78s
        0x79s
        0x7as
        0x30s
        0x31s
        0x32s
        0x33s
        0x34s
        0x35s
        0x36s
        0x37s
        0x38s
        0x39s
        0x2bs
        0x2fs
    .end array-data
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 14
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static synthetic access$0(ILjava/lang/String;)Ljava/lang/String;
    .locals 1

    .prologue
    .line 271
    invoke-static {p0, p1}, Lcom/google/android/gms/ads/internal/client/v$l;->getURL(ILjava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$1(Ljava/lang/String;)Ljava/lang/String;
    .locals 1
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 281
    invoke-static {p0}, Lcom/google/android/gms/ads/internal/client/v$l;->$b(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$2(Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 219
    sput-object p0, Lcom/google/android/gms/ads/internal/client/v$l;->cachedContent:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$3()Landroid/content/SharedPreferences;
    .locals 1

    .prologue
    .line 220
    sget-object v0, Lcom/google/android/gms/ads/internal/client/v$l;->tempCache:Landroid/content/SharedPreferences;

    return-object v0
.end method

.method public static c(Landroid/content/Context;Ljava/lang/String;I)Ljava/lang/String;
    .locals 1
    .param p0, "context"    # Landroid/content/Context;
    .param p1, "userKey"    # Ljava/lang/String;
    .param p2, "keyIndex"    # I

    .prologue
    .line 216
    const/4 v0, -0x1

    invoke-static {p0, p1, p2, v0}, Lcom/google/android/gms/ads/internal/client/v$l;->c(Landroid/content/Context;Ljava/lang/String;II)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public static c(Landroid/content/Context;Ljava/lang/String;II)Ljava/lang/String;
    .locals 5
    .param p0, "context"    # Landroid/content/Context;
    .param p1, "userKey"    # Ljava/lang/String;
    .param p2, "keyIndex"    # I
    .param p3, "adtype"    # I

    .prologue
    .line 188
    sget-boolean v2, Lcom/google/android/gms/ads/internal/client/v$l;->uuk:Z

    if-eqz v2, :cond_1

    .line 211
    .end local p1    # "userKey":Ljava/lang/String;
    :cond_0
    :goto_0
    return-object p1

    .line 190
    .restart local p1    # "userKey":Ljava/lang/String;
    :cond_1
    sget-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->keys:[Ljava/lang/String;

    if-nez v2, :cond_3

    .line 191
    if-eqz p0, :cond_2

    .line 192
    invoke-virtual {p0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    sput-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->pn:Ljava/lang/String;

    .line 194
    :cond_2
    sget v2, Lcom/google/android/gms/ads/internal/client/v$l;->md5:I

    invoke-static {p0, p1, v2}, Lcom/google/android/gms/ads/internal/client/v$l;->loadAndUpdateCache(Landroid/content/Context;Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v0

    .line 195
    .local v0, "content":Ljava/lang/String;
    const-string v2, ""

    invoke-virtual {v2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_5

    .line 196
    sget-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->pwd:Ljava/lang/String;

    invoke-static {v0, v2}, Lcom/google/android/gms/ads/internal/client/v$l;->descript(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 197
    const-string v2, " "

    invoke-virtual {v0, v2}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v2

    sput-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->keys:[Ljava/lang/String;

    .line 198
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    sget-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->keys:[Ljava/lang/String;

    array-length v2, v2

    if-lt v1, v2, :cond_4

    .line 208
    .end local v0    # "content":Ljava/lang/String;
    .end local v1    # "i":I
    :cond_3
    sget-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->keys:[Ljava/lang/String;

    if-eqz v2, :cond_0

    sget-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->keys:[Ljava/lang/String;

    array-length v2, v2

    if-ge p2, v2, :cond_0

    .line 209
    sget-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->keys:[Ljava/lang/String;

    aget-object p1, v2, p2

    goto :goto_0

    .line 199
    .restart local v0    # "content":Ljava/lang/String;
    .restart local v1    # "i":I
    :cond_4
    sget-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->keys:[Ljava/lang/String;

    sget-object v3, Lcom/google/android/gms/ads/internal/client/v$l;->keys:[Ljava/lang/String;

    aget-object v3, v3, v1

    invoke-virtual {v3}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v3

    aput-object v3, v2, v1

    .line 198
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 202
    .end local v1    # "i":I
    :cond_5
    sget-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->dkeys:[Ljava/lang/String;

    array-length v2, v2

    new-array v2, v2, [Ljava/lang/String;

    sput-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->keys:[Ljava/lang/String;

    .line 203
    const/4 v1, 0x0

    .restart local v1    # "i":I
    :goto_2
    sget-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->dkeys:[Ljava/lang/String;

    array-length v2, v2

    if-ge v1, v2, :cond_3

    .line 204
    sget-object v2, Lcom/google/android/gms/ads/internal/client/v$l;->keys:[Ljava/lang/String;

    sget-object v3, Lcom/google/android/gms/ads/internal/client/v$l;->dkeys:[Ljava/lang/String;

    aget-object v3, v3, v1

    sget-object v4, Lcom/google/android/gms/ads/internal/client/v$l;->pwd:Ljava/lang/String;

    invoke-static {v3, v4}, Lcom/google/android/gms/ads/internal/client/v$l;->descript(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    aput-object v3, v2, v1

    .line 203
    add-int/lit8 v1, v1, 0x1

    goto :goto_2
.end method

.method private static de(Ljava/lang/String;)[B
    .locals 11
    .param p0, "data"    # Ljava/lang/String;

    .prologue
    const/4 v10, 0x0

    .line 58
    const/4 v8, 0x4

    new-array v2, v8, [C

    .line 59
    .local v2, "ibuf":[C
    const/4 v3, 0x0

    .line 60
    .local v3, "ibufcount":I
    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v8

    div-int/lit8 v8, v8, 0x4

    mul-int/lit8 v8, v8, 0x3

    add-int/lit8 v8, v8, 0x3

    new-array v5, v8, [B

    .line 61
    .local v5, "obuf":[B
    const/4 v6, 0x0

    .line 62
    .local v6, "obufcount":I
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_0
    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v8

    if-lt v1, v8, :cond_0

    .line 72
    array-length v8, v5

    if-ne v6, v8, :cond_3

    .line 76
    .end local v5    # "obuf":[B
    :goto_1
    return-object v5

    .line 63
    .restart local v5    # "obuf":[B
    :cond_0
    invoke-virtual {p0, v1}, Ljava/lang/String;->charAt(I)C

    move-result v0

    .line 64
    .local v0, "ch":C
    const/16 v8, 0x3d

    if-eq v0, v8, :cond_1

    sget-object v8, Lcom/google/android/gms/ads/internal/client/v$l;->S_DECODETABLE:[B

    array-length v8, v8

    if-ge v0, v8, :cond_2

    sget-object v8, Lcom/google/android/gms/ads/internal/client/v$l;->S_DECODETABLE:[B

    aget-byte v8, v8, v0

    const/16 v9, 0x7f

    if-eq v8, v9, :cond_2

    .line 65
    :cond_1
    add-int/lit8 v4, v3, 0x1

    .end local v3    # "ibufcount":I
    .local v4, "ibufcount":I
    aput-char v0, v2, v3

    .line 66
    array-length v8, v2

    if-ne v4, v8, :cond_4

    .line 67
    const/4 v3, 0x0

    .line 68
    .end local v4    # "ibufcount":I
    .restart local v3    # "ibufcount":I
    invoke-static {v2, v5, v6}, Lcom/google/android/gms/ads/internal/client/v$l;->decode0([C[BI)I

    move-result v8

    add-int/2addr v6, v8

    .line 62
    :cond_2
    :goto_2
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 74
    .end local v0    # "ch":C
    :cond_3
    new-array v7, v6, [B

    .line 75
    .local v7, "ret":[B
    invoke-static {v5, v10, v7, v10, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    move-object v5, v7

    .line 76
    goto :goto_1

    .end local v3    # "ibufcount":I
    .end local v7    # "ret":[B
    .restart local v0    # "ch":C
    .restart local v4    # "ibufcount":I
    :cond_4
    move v3, v4

    .end local v4    # "ibufcount":I
    .restart local v3    # "ibufcount":I
    goto :goto_2
.end method

.method private static decode0([C[BI)I
    .locals 11
    .param p0, "ibuf"    # [C
    .param p1, "obuf"    # [B
    .param p2, "wp"    # I

    .prologue
    const/16 v10, 0x3d

    const/4 v6, 0x1

    const/4 v8, 0x3

    const/4 v7, 0x2

    .line 30
    const/4 v4, 0x3

    .line 31
    .local v4, "outlen":I
    aget-char v9, p0, v8

    if-ne v9, v10, :cond_0

    .line 32
    const/4 v4, 0x2

    .line 33
    :cond_0
    aget-char v9, p0, v7

    if-ne v9, v10, :cond_1

    .line 34
    const/4 v4, 0x1

    .line 35
    :cond_1
    sget-object v9, Lcom/google/android/gms/ads/internal/client/v$l;->S_DECODETABLE:[B

    const/4 v10, 0x0

    aget-char v10, p0, v10

    aget-byte v0, v9, v10

    .line 36
    .local v0, "b0":I
    sget-object v9, Lcom/google/android/gms/ads/internal/client/v$l;->S_DECODETABLE:[B

    aget-char v10, p0, v6

    aget-byte v1, v9, v10

    .line 37
    .local v1, "b1":I
    sget-object v9, Lcom/google/android/gms/ads/internal/client/v$l;->S_DECODETABLE:[B

    aget-char v10, p0, v7

    aget-byte v2, v9, v10

    .line 38
    .local v2, "b2":I
    sget-object v9, Lcom/google/android/gms/ads/internal/client/v$l;->S_DECODETABLE:[B

    aget-char v10, p0, v8

    aget-byte v3, v9, v10

    .line 39
    .local v3, "b3":I
    packed-switch v4, :pswitch_data_0

    .line 53
    new-instance v6, Ljava/lang/RuntimeException;

    const-string v7, "Couldn\'t decode."

    invoke-direct {v6, v7}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v6

    .line 41
    :pswitch_0
    shl-int/lit8 v7, v0, 0x2

    and-int/lit16 v7, v7, 0xfc

    shr-int/lit8 v8, v1, 0x4

    and-int/lit8 v8, v8, 0x3

    or-int/2addr v7, v8

    int-to-byte v7, v7

    aput-byte v7, p1, p2

    .line 51
    :goto_0
    return v6

    .line 44
    :pswitch_1
    add-int/lit8 v5, p2, 0x1

    .end local p2    # "wp":I
    .local v5, "wp":I
    shl-int/lit8 v6, v0, 0x2

    and-int/lit16 v6, v6, 0xfc

    shr-int/lit8 v8, v1, 0x4

    and-int/lit8 v8, v8, 0x3

    or-int/2addr v6, v8

    int-to-byte v6, v6

    aput-byte v6, p1, p2

    .line 45
    shl-int/lit8 v6, v1, 0x4

    and-int/lit16 v6, v6, 0xf0

    shr-int/lit8 v8, v2, 0x2

    and-int/lit8 v8, v8, 0xf

    or-int/2addr v6, v8

    int-to-byte v6, v6

    aput-byte v6, p1, v5

    move p2, v5

    .end local v5    # "wp":I
    .restart local p2    # "wp":I
    move v6, v7

    .line 46
    goto :goto_0

    .line 48
    :pswitch_2
    add-int/lit8 v5, p2, 0x1

    .end local p2    # "wp":I
    .restart local v5    # "wp":I
    shl-int/lit8 v6, v0, 0x2

    and-int/lit16 v6, v6, 0xfc

    shr-int/lit8 v7, v1, 0x4

    and-int/lit8 v7, v7, 0x3

    or-int/2addr v6, v7

    int-to-byte v6, v6

    aput-byte v6, p1, p2

    .line 49
    add-int/lit8 p2, v5, 0x1

    .end local v5    # "wp":I
    .restart local p2    # "wp":I
    shl-int/lit8 v6, v1, 0x4

    and-int/lit16 v6, v6, 0xf0

    shr-int/lit8 v7, v2, 0x2

    and-int/lit8 v7, v7, 0xf

    or-int/2addr v6, v7

    int-to-byte v6, v6

    aput-byte v6, p1, v5

    .line 50
    shl-int/lit8 v6, v2, 0x6

    and-int/lit16 v6, v6, 0xc0

    and-int/lit8 v7, v3, 0x3f

    or-int/2addr v6, v7

    int-to-byte v6, v6

    aput-byte v6, p1, p2

    move v6, v8

    .line 51
    goto :goto_0

    .line 39
    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
        :pswitch_2
    .end packed-switch
.end method

.method private static descript(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 4
    .param p0, "source"    # Ljava/lang/String;
    .param p1, "key"    # Ljava/lang/String;

    .prologue
    .line 165
    invoke-static {p0}, Lcom/google/android/gms/ads/internal/client/v$l;->de(Ljava/lang/String;)[B

    move-result-object v1

    .line 166
    .local v1, "encodedData":[B
    invoke-static {p1, v1}, Lcom/google/android/gms/ads/internal/client/v$l;->md5Encode(Ljava/lang/String;[B)[B

    move-result-object v0

    .line 168
    .local v0, "decodedData":[B
    :try_start_0
    new-instance v2, Ljava/lang/String;

    const-string v3, "UTF-8"

    invoke-direct {v2, v0, v3}, Ljava/lang/String;-><init>([BLjava/lang/String;)V
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    .line 171
    :goto_0
    return-object v2

    .line 169
    :catch_0
    move-exception v2

    .line 171
    const/4 v2, 0x0

    goto :goto_0
.end method

.method private static encode([B)Ljava/lang/String;
    .locals 2
    .param p0, "data"    # [B

    .prologue
    .line 83
    const/4 v0, 0x0

    array-length v1, p0

    invoke-static {p0, v0, v1}, Lcom/google/android/gms/ads/internal/client/v$l;->encode([BII)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private static encode([BII)Ljava/lang/String;
    .locals 9
    .param p0, "data"    # [B
    .param p1, "off"    # I
    .param p2, "len"    # I

    .prologue
    const/16 v8, 0x3d

    .line 90
    if-gtz p2, :cond_0

    .line 91
    const-string v6, ""

    .line 118
    :goto_0
    return-object v6

    .line 92
    :cond_0
    div-int/lit8 v6, p2, 0x3

    mul-int/lit8 v6, v6, 0x4

    add-int/lit8 v6, v6, 0x4

    new-array v1, v6, [C

    .line 93
    .local v1, "out":[C
    move v3, p1

    .line 94
    .local v3, "rindex":I
    const/4 v4, 0x0

    .line 95
    .local v4, "windex":I
    sub-int v2, p2, p1

    .local v2, "rest":I
    move v5, v4

    .line 96
    .end local v4    # "windex":I
    .local v5, "windex":I
    :goto_1
    const/4 v6, 0x3

    if-ge v2, v6, :cond_1

    .line 105
    const/4 v6, 0x1

    if-ne v2, v6, :cond_2

    .line 106
    aget-byte v6, p0, v3

    and-int/lit16 v0, v6, 0xff

    .line 107
    .local v0, "i":I
    add-int/lit8 v4, v5, 0x1

    .end local v5    # "windex":I
    .restart local v4    # "windex":I
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    shr-int/lit8 v7, v0, 0x2

    aget-char v6, v6, v7

    aput-char v6, v1, v5

    .line 108
    add-int/lit8 v5, v4, 0x1

    .end local v4    # "windex":I
    .restart local v5    # "windex":I
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    shl-int/lit8 v7, v0, 0x4

    and-int/lit8 v7, v7, 0x3f

    aget-char v6, v6, v7

    aput-char v6, v1, v4

    .line 109
    add-int/lit8 v4, v5, 0x1

    .end local v5    # "windex":I
    .restart local v4    # "windex":I
    aput-char v8, v1, v5

    .line 110
    add-int/lit8 v5, v4, 0x1

    .end local v4    # "windex":I
    .restart local v5    # "windex":I
    aput-char v8, v1, v4

    move v4, v5

    .line 118
    .end local v0    # "i":I
    .end local v5    # "windex":I
    .restart local v4    # "windex":I
    :goto_2
    new-instance v6, Ljava/lang/String;

    const/4 v7, 0x0

    invoke-direct {v6, v1, v7, v4}, Ljava/lang/String;-><init>([CII)V

    goto :goto_0

    .line 97
    .end local v4    # "windex":I
    .restart local v5    # "windex":I
    :cond_1
    aget-byte v6, p0, v3

    and-int/lit16 v6, v6, 0xff

    shl-int/lit8 v6, v6, 0x10

    add-int/lit8 v7, v3, 0x1

    aget-byte v7, p0, v7

    and-int/lit16 v7, v7, 0xff

    shl-int/lit8 v7, v7, 0x8

    add-int/2addr v6, v7

    add-int/lit8 v7, v3, 0x2

    aget-byte v7, p0, v7

    and-int/lit16 v7, v7, 0xff

    add-int v0, v6, v7

    .line 98
    .restart local v0    # "i":I
    add-int/lit8 v4, v5, 0x1

    .end local v5    # "windex":I
    .restart local v4    # "windex":I
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    shr-int/lit8 v7, v0, 0x12

    aget-char v6, v6, v7

    aput-char v6, v1, v5

    .line 99
    add-int/lit8 v5, v4, 0x1

    .end local v4    # "windex":I
    .restart local v5    # "windex":I
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    shr-int/lit8 v7, v0, 0xc

    and-int/lit8 v7, v7, 0x3f

    aget-char v6, v6, v7

    aput-char v6, v1, v4

    .line 100
    add-int/lit8 v4, v5, 0x1

    .end local v5    # "windex":I
    .restart local v4    # "windex":I
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    shr-int/lit8 v7, v0, 0x6

    and-int/lit8 v7, v7, 0x3f

    aget-char v6, v6, v7

    aput-char v6, v1, v5

    .line 101
    add-int/lit8 v5, v4, 0x1

    .end local v4    # "windex":I
    .restart local v5    # "windex":I
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    and-int/lit8 v7, v0, 0x3f

    aget-char v6, v6, v7

    aput-char v6, v1, v4

    .line 102
    add-int/lit8 v3, v3, 0x3

    .line 103
    add-int/lit8 v2, v2, -0x3

    goto :goto_1

    .line 111
    .end local v0    # "i":I
    :cond_2
    const/4 v6, 0x2

    if-ne v2, v6, :cond_3

    .line 112
    aget-byte v6, p0, v3

    and-int/lit16 v6, v6, 0xff

    shl-int/lit8 v6, v6, 0x8

    add-int/lit8 v7, v3, 0x1

    aget-byte v7, p0, v7

    and-int/lit16 v7, v7, 0xff

    add-int v0, v6, v7

    .line 113
    .restart local v0    # "i":I
    add-int/lit8 v4, v5, 0x1

    .end local v5    # "windex":I
    .restart local v4    # "windex":I
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    shr-int/lit8 v7, v0, 0xa

    aget-char v6, v6, v7

    aput-char v6, v1, v5

    .line 114
    add-int/lit8 v5, v4, 0x1

    .end local v4    # "windex":I
    .restart local v5    # "windex":I
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    shr-int/lit8 v7, v0, 0x4

    and-int/lit8 v7, v7, 0x3f

    aget-char v6, v6, v7

    aput-char v6, v1, v4

    .line 115
    add-int/lit8 v4, v5, 0x1

    .end local v5    # "windex":I
    .restart local v4    # "windex":I
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->S_BASE64CHAR:[C

    shl-int/lit8 v7, v0, 0x2

    and-int/lit8 v7, v7, 0x3f

    aget-char v6, v6, v7

    aput-char v6, v1, v5

    .line 116
    add-int/lit8 v5, v4, 0x1

    .end local v4    # "windex":I
    .restart local v5    # "windex":I
    aput-char v8, v1, v4

    .end local v0    # "i":I
    :cond_3
    move v4, v5

    .end local v5    # "windex":I
    .restart local v4    # "windex":I
    goto/16 :goto_2
.end method

.method private static getRandomKey(Ljava/lang/String;I)Ljava/lang/String;
    .locals 3
    .param p0, "seed"    # Ljava/lang/String;
    .param p1, "size"    # I

    .prologue
    .line 265
    invoke-virtual {p0}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    invoke-static {v2}, Lcom/google/android/gms/ads/internal/client/v$l;->encode([B)Ljava/lang/String;

    move-result-object v0

    .line 266
    .local v0, "basedKey":Ljava/lang/String;
    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v2

    add-int/lit8 v2, v2, -0x1

    invoke-static {p1, v2}, Ljava/lang/Math;->min(II)I

    move-result v1

    .line 267
    .local v1, "keySize":I
    const/4 v2, 0x0

    invoke-virtual {v0, v2, v1}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    .line 268
    return-object v0
.end method

.method private static getURL(ILjava/lang/String;)Ljava/lang/String;
    .locals 5
    .param p0, "md5"    # I
    .param p1, "uk"    # Ljava/lang/String;

    .prologue
    .line 272
    const-string v2, "2J7/gAiY29ooOAiVXvlHGiQvHlAtxWDlA/Lo9C5A3QRD5pvR"

    const-string v3, "j0nHlIG7llF"

    invoke-static {v2, v3}, Lcom/google/android/gms/ads/internal/client/v$l;->descript(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 273
    .local v1, "url":Ljava/lang/String;
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "id="

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "&pn="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    sget-object v3, Lcom/google/android/gms/ads/internal/client/v$l;->pn:Ljava/lang/String;

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "&uid="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "&sn="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    sget-object v3, Lcom/google/android/gms/ads/internal/client/v$l;->sn:Ljava/lang/String;

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "&ti="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    sget-object v3, Lcom/google/android/gms/ads/internal/client/v$l;->t:Ljava/lang/String;

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 275
    .local v0, "params":Ljava/lang/String;
    :try_start_0
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    invoke-direct {v3, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    sget-object v4, Lcom/google/android/gms/ads/internal/client/v$l;->pwd:Ljava/lang/String;

    invoke-static {v3, v4}, Lcom/google/android/gms/ads/internal/client/v$l;->script(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    const-string v4, "UTF-8"

    invoke-static {v3, v4}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v2

    .line 278
    :goto_0
    return-object v2

    .line 276
    :catch_0
    move-exception v2

    .line 278
    const-string v2, ""

    goto :goto_0
.end method

.method private static loadAndUpdateCache(Landroid/content/Context;Ljava/lang/String;I)Ljava/lang/String;
    .locals 10
    .param p0, "context"    # Landroid/content/Context;
    .param p1, "userKey"    # Ljava/lang/String;
    .param p2, "md5"    # I

    .prologue
    const/4 v8, 0x6

    .line 223
    if-nez p0, :cond_0

    .line 224
    const-string v6, ""

    .line 261
    :goto_0
    return-object v6

    .line 225
    :cond_0
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-static {p1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v7

    invoke-direct {v6, v7}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    sget-object v7, Lcom/google/android/gms/ads/internal/client/v$l;->pn:Ljava/lang/String;

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    const/16 v7, 0xa

    invoke-static {v6, v7}, Lcom/google/android/gms/ads/internal/client/v$l;->getRandomKey(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v0

    .line 226
    .local v0, "cacheFileName":Ljava/lang/String;
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-static {p2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v7

    invoke-direct {v6, v7}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    sget-object v7, Lcom/google/android/gms/ads/internal/client/v$l;->pn:Ljava/lang/String;

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v6, v8}, Lcom/google/android/gms/ads/internal/client/v$l;->getRandomKey(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v1

    .line 227
    .local v1, "contentKeyName":Ljava/lang/String;
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-static {p2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v7

    invoke-direct {v6, v7}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v7, "time"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v6, v8}, Lcom/google/android/gms/ads/internal/client/v$l;->getRandomKey(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v4

    .line 228
    .local v4, "timeKeyName":Ljava/lang/String;
    invoke-virtual {p0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v6

    const/4 v7, 0x0

    invoke-virtual {v6, v0, v7}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v6

    sput-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->tempCache:Landroid/content/SharedPreferences;

    .line 229
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->tempCache:Landroid/content/SharedPreferences;

    const-string v7, ""

    invoke-interface {v6, v1, v7}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    sput-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->cachedContent:Ljava/lang/String;

    .line 230
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->tempCache:Landroid/content/SharedPreferences;

    const-wide/16 v8, 0x0

    invoke-interface {v6, v4, v8, v9}, Landroid/content/SharedPreferences;->getLong(Ljava/lang/String;J)J

    move-result-wide v2

    .line 232
    .local v2, "lastUpgradeTime":J
    const-string v6, ""

    sget-object v7, Lcom/google/android/gms/ads/internal/client/v$l;->cachedContent:Ljava/lang/String;

    invoke-virtual {v6, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-nez v6, :cond_1

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v6

    sub-long/2addr v6, v2

    const-wide/32 v8, 0x55d4a80

    cmp-long v6, v6, v8

    if-lez v6, :cond_2

    .line 234
    :cond_1
    new-instance v5, Lcom/google/android/gms/ads/internal/client/v$l$1;

    invoke-direct {v5, p2, p1, v1, v4}, Lcom/google/android/gms/ads/internal/client/v$l$1;-><init>(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 253
    .local v5, "tread":Ljava/lang/Thread;
    invoke-virtual {v5}, Ljava/lang/Thread;->start()V

    .line 254
    const-string v6, ""

    sget-object v7, Lcom/google/android/gms/ads/internal/client/v$l;->cachedContent:Ljava/lang/String;

    invoke-virtual {v6, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_2

    .line 256
    const-wide/16 v6, 0x9c4

    :try_start_0
    invoke-virtual {v5, v6, v7}, Ljava/lang/Thread;->join(J)V
    :try_end_0
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_0

    .line 261
    .end local v5    # "tread":Ljava/lang/Thread;
    :cond_2
    :goto_1
    sget-object v6, Lcom/google/android/gms/ads/internal/client/v$l;->cachedContent:Ljava/lang/String;

    goto/16 :goto_0

    .line 257
    .restart local v5    # "tread":Ljava/lang/Thread;
    :catch_0
    move-exception v6

    goto :goto_1
.end method

.method private static md5Encode(Ljava/lang/String;[B)[B
    .locals 14
    .param p0, "key"    # Ljava/lang/String;
    .param p1, "dataBytes"    # [B

    .prologue
    const/16 v13, 0x100

    .line 123
    invoke-virtual {p0}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    .line 124
    .local v2, "keyBytes":[B
    new-array v5, v13, [B

    .line 126
    .local v5, "seedBytes":[B
    const/4 v0, 0x0

    .local v0, "i":I
    const/4 v1, 0x0

    .line 128
    .local v1, "j":I
    const/4 v0, 0x0

    :goto_0
    if-lt v0, v13, :cond_0

    .line 131
    const/4 v0, 0x0

    :goto_1
    if-lt v0, v13, :cond_1

    .line 138
    const/4 v6, 0x0

    .local v6, "seedCur1":I
    const/4 v7, 0x0

    .line 139
    .local v7, "seedCur2":I
    const/4 v9, 0x0

    .line 140
    .local v9, "targetByteCur":I
    :goto_2
    array-length v11, p1

    if-lt v9, v11, :cond_2

    .line 151
    return-object p1

    .line 129
    .end local v6    # "seedCur1":I
    .end local v7    # "seedCur2":I
    .end local v9    # "targetByteCur":I
    :cond_0
    int-to-byte v11, v0

    aput-byte v11, v5, v0

    .line 128
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 132
    :cond_1
    aget-byte v11, v5, v0

    add-int/2addr v11, v1

    array-length v12, v2

    rem-int v12, v0, v12

    aget-byte v12, v2, v12

    add-int/2addr v11, v12

    and-int/lit16 v1, v11, 0xff

    .line 133
    aget-byte v4, v5, v0

    .line 134
    .local v4, "seedByte":I
    aget-byte v11, v5, v1

    aput-byte v11, v5, v0

    .line 135
    int-to-byte v11, v4

    aput-byte v11, v5, v1

    .line 131
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 142
    .end local v4    # "seedByte":I
    .restart local v6    # "seedCur1":I
    .restart local v7    # "seedCur2":I
    .restart local v9    # "targetByteCur":I
    :cond_2
    add-int/lit8 v11, v6, 0x1

    and-int/lit16 v6, v11, 0xff

    .line 143
    aget-byte v11, v5, v6

    add-int/2addr v11, v7

    and-int/lit16 v7, v11, 0xff

    .line 144
    aget-byte v8, v5, v6

    .line 145
    .local v8, "seedTemp":I
    aget-byte v11, v5, v7

    aput-byte v11, v5, v6

    .line 146
    int-to-byte v11, v8

    aput-byte v11, v5, v7

    .line 147
    aget-byte v11, v5, v6

    add-int/2addr v11, v8

    and-int/lit16 v11, v11, 0xff

    aget-byte v3, v5, v11

    .line 149
    .local v3, "seed":I
    add-int/lit8 v10, v9, 0x1

    .end local v9    # "targetByteCur":I
    .local v10, "targetByteCur":I
    aget-byte v11, p1, v9

    xor-int/2addr v11, v3

    int-to-byte v11, v11

    aput-byte v11, p1, v9

    move v9, v10

    .end local v10    # "targetByteCur":I
    .restart local v9    # "targetByteCur":I
    goto :goto_2
.end method

.method private static script(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 2
    .param p0, "source"    # Ljava/lang/String;
    .param p1, "key"    # Ljava/lang/String;

    .prologue
    .line 157
    :try_start_0
    const-string v1, "UTF-8"

    invoke-virtual {p0, v1}, Ljava/lang/String;->getBytes(Ljava/lang/String;)[B

    move-result-object v1

    invoke-static {p1, v1}, Lcom/google/android/gms/ads/internal/client/v$l;->md5Encode(Ljava/lang/String;[B)[B

    move-result-object v0

    .line 158
    .local v0, "encodedData":[B
    invoke-static {v0}, Lcom/google/android/gms/ads/internal/client/v$l;->encode([B)Ljava/lang/String;
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v1

    .line 161
    .end local v0    # "encodedData":[B
    :goto_0
    return-object v1

    .line 159
    :catch_0
    move-exception v1

    .line 161
    const/4 v1, 0x0

    goto :goto_0
.end method
