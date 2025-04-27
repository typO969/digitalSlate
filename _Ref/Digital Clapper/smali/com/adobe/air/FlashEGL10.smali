.class public Lcom/adobe/air/FlashEGL10;
.super Ljava/lang/Object;
.source "FlashEGL10.java"

# interfaces
.implements Lcom/adobe/air/FlashEGL;


# static fields
.field private static EGL_BUFFER_DESTROYED:I

.field private static EGL_BUFFER_PRESERVED:I

.field private static EGL_CONTEXT_CLIENT_VERSION:I

.field private static EGL_COVERAGE_BUFFERS_NV:I

.field private static EGL_COVERAGE_SAMPLES_NV:I

.field private static EGL_OPENGL_ES2_BIT:I

.field private static EGL_SWAP_BEHAVIOR:I

.field private static TAG:Ljava/lang/String;

.field private static cfgAttrs:[I

.field private static fbPBufferSurfaceAttrs:[I

.field private static fbWindowSurfaceOffAttrs:[I

.field private static fbWindowSurfaceOnAttrs:[I


# instance fields
.field private kAlphaBits:I

.field private kBlueBits:I

.field private kColorBits:I

.field private kConfigId:I

.field private kCsaaSamp:I

.field private kDepthBits:I

.field private kGreenBits:I

.field private kMsaaSamp:I

.field private kNumElements:I

.field private kRedBits:I

.field private kStencilBits:I

.field private kSurfaceTypes:I

.field private kSwapPreserve:I

.field private kSwapPreserveDefault:I

.field private kSwapPreserveOff:I

.field private kSwapPreserveOn:I

.field private mEgl:Ljavax/microedition/khronos/egl/EGL10;

.field private mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

.field private mEglConfigCount:I

.field private mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

.field volatile mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

.field private mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

.field private mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

.field private mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

.field private mEglVersion:[I

.field private mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

.field private mIsARGBSurface:Z

.field private mIsBufferPreserve:Z

.field private mIsES3Device:Z

.field private mIsGPUOOM:Z

.field private mPbufferConfigCount:I

.field private mPixmapConfigCount:I

.field private mWindowConfigCount:I


# direct methods
.method static constructor <clinit>()V
    .locals 8

    .prologue
    const/4 v7, 0x3

    const/4 v6, 0x2

    const/4 v5, 0x1

    const/4 v4, 0x0

    const/4 v3, -0x1

    .line 32
    const-string v0, "FlashEGL10"

    sput-object v0, Lcom/adobe/air/FlashEGL10;->TAG:Ljava/lang/String;

    .line 33
    const/16 v0, 0x3098

    sput v0, Lcom/adobe/air/FlashEGL10;->EGL_CONTEXT_CLIENT_VERSION:I

    .line 34
    const/4 v0, 0x4

    sput v0, Lcom/adobe/air/FlashEGL10;->EGL_OPENGL_ES2_BIT:I

    .line 36
    const/16 v0, 0x30e0

    sput v0, Lcom/adobe/air/FlashEGL10;->EGL_COVERAGE_BUFFERS_NV:I

    .line 37
    const/16 v0, 0x30e1

    sput v0, Lcom/adobe/air/FlashEGL10;->EGL_COVERAGE_SAMPLES_NV:I

    .line 40
    const/16 v0, 0x3093

    sput v0, Lcom/adobe/air/FlashEGL10;->EGL_SWAP_BEHAVIOR:I

    .line 41
    const/16 v0, 0x3094

    sput v0, Lcom/adobe/air/FlashEGL10;->EGL_BUFFER_PRESERVED:I

    .line 42
    const/16 v0, 0x3095

    sput v0, Lcom/adobe/air/FlashEGL10;->EGL_BUFFER_DESTROYED:I

    .line 52
    const/16 v0, 0x9

    new-array v0, v0, [I

    const/16 v1, 0x3033

    aput v1, v0, v4

    aput v3, v0, v5

    const/16 v1, 0x3025

    aput v1, v0, v6

    aput v3, v0, v7

    const/4 v1, 0x4

    const/16 v2, 0x3026

    aput v2, v0, v1

    const/4 v1, 0x5

    aput v3, v0, v1

    const/4 v1, 0x6

    const/16 v2, 0x3040

    aput v2, v0, v1

    const/4 v1, 0x7

    sget v2, Lcom/adobe/air/FlashEGL10;->EGL_OPENGL_ES2_BIT:I

    aput v2, v0, v1

    const/16 v1, 0x8

    const/16 v2, 0x3038

    aput v2, v0, v1

    sput-object v0, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    .line 62
    new-array v0, v7, [I

    sget v1, Lcom/adobe/air/FlashEGL10;->EGL_SWAP_BEHAVIOR:I

    aput v1, v0, v4

    sget v1, Lcom/adobe/air/FlashEGL10;->EGL_BUFFER_PRESERVED:I

    aput v1, v0, v5

    const/16 v1, 0x3038

    aput v1, v0, v6

    sput-object v0, Lcom/adobe/air/FlashEGL10;->fbWindowSurfaceOnAttrs:[I

    .line 68
    new-array v0, v7, [I

    sget v1, Lcom/adobe/air/FlashEGL10;->EGL_SWAP_BEHAVIOR:I

    aput v1, v0, v4

    sget v1, Lcom/adobe/air/FlashEGL10;->EGL_BUFFER_DESTROYED:I

    aput v1, v0, v5

    const/16 v1, 0x3038

    aput v1, v0, v6

    sput-object v0, Lcom/adobe/air/FlashEGL10;->fbWindowSurfaceOffAttrs:[I

    .line 74
    const/4 v0, 0x5

    new-array v0, v0, [I

    fill-array-data v0, :array_0

    sput-object v0, Lcom/adobe/air/FlashEGL10;->fbPBufferSurfaceAttrs:[I

    return-void

    nop

    :array_0
    .array-data 4
        0x3057
        0x40
        0x3056
        0x40
        0x3038
    .end array-data
.end method

.method public constructor <init>()V
    .locals 5

    .prologue
    const/4 v4, 0x2

    const/4 v3, 0x1

    const/4 v2, 0x0

    const/4 v1, 0x0

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 44
    iput v1, p0, Lcom/adobe/air/FlashEGL10;->kSurfaceTypes:I

    iput v3, p0, Lcom/adobe/air/FlashEGL10;->kConfigId:I

    iput v4, p0, Lcom/adobe/air/FlashEGL10;->kRedBits:I

    const/4 v0, 0x3

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->kGreenBits:I

    const/4 v0, 0x4

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->kBlueBits:I

    const/4 v0, 0x5

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->kAlphaBits:I

    const/4 v0, 0x6

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->kColorBits:I

    const/4 v0, 0x7

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->kDepthBits:I

    const/16 v0, 0x8

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->kStencilBits:I

    const/16 v0, 0x9

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->kMsaaSamp:I

    const/16 v0, 0xa

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->kCsaaSamp:I

    const/16 v0, 0xb

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->kSwapPreserve:I

    const/16 v0, 0xc

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->kNumElements:I

    .line 49
    iput v1, p0, Lcom/adobe/air/FlashEGL10;->kSwapPreserveDefault:I

    iput v3, p0, Lcom/adobe/air/FlashEGL10;->kSwapPreserveOn:I

    iput v4, p0, Lcom/adobe/air/FlashEGL10;->kSwapPreserveOff:I

    .line 837
    iput-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    .line 838
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_DISPLAY:Ljavax/microedition/khronos/egl/EGLDisplay;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    .line 839
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 840
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 841
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 842
    iput-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    .line 843
    iput-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    .line 844
    iput-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglVersion:[I

    .line 845
    iput v1, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigCount:I

    .line 846
    iput v1, p0, Lcom/adobe/air/FlashEGL10;->mWindowConfigCount:I

    .line 847
    iput v1, p0, Lcom/adobe/air/FlashEGL10;->mPixmapConfigCount:I

    .line 848
    iput v1, p0, Lcom/adobe/air/FlashEGL10;->mPbufferConfigCount:I

    .line 849
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 850
    iput-boolean v1, p0, Lcom/adobe/air/FlashEGL10;->mIsARGBSurface:Z

    .line 851
    iput-boolean v1, p0, Lcom/adobe/air/FlashEGL10;->mIsGPUOOM:Z

    .line 852
    iput-boolean v1, p0, Lcom/adobe/air/FlashEGL10;->mIsBufferPreserve:Z

    .line 853
    iput-boolean v1, p0, Lcom/adobe/air/FlashEGL10;->mIsES3Device:Z

    return-void
.end method

.method private XX(II)I
    .locals 1

    .prologue
    .line 99
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kNumElements:I

    mul-int/2addr v0, p1

    add-int/2addr v0, p2

    return v0
.end method

.method private checkEglError(Ljava/lang/String;)I
    .locals 7

    .prologue
    const/16 v6, 0x3000

    .line 797
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    invoke-interface {v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetError()I

    move-result v0

    .line 798
    if-eq v0, v6, :cond_3

    .line 800
    iget-boolean v1, p0, Lcom/adobe/air/FlashEGL10;->mIsGPUOOM:Z

    if-nez v1, :cond_3

    const/16 v1, 0x3003

    if-ne v0, v1, :cond_3

    .line 805
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v1, v2, :cond_1

    .line 807
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    invoke-interface {v1, v2, v3}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroySurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z

    .line 808
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    invoke-interface {v1}, Ljavax/microedition/khronos/egl/EGL10;->eglGetError()I

    move-result v1

    .line 809
    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 810
    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 811
    if-eq v1, v6, :cond_0

    .line 814
    :cond_0
    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 815
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v3, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v4, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v5, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v1, v2, v3, v4, v5}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 816
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    invoke-interface {v1}, Ljavax/microedition/khronos/egl/EGL10;->eglGetError()I

    move-result v1

    .line 817
    if-eq v1, v6, :cond_1

    .line 822
    :cond_1
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v1, v2, :cond_2

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-eq v1, v2, :cond_2

    .line 824
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 825
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v5, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v1, v2, v3, v4, v5}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 826
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    invoke-interface {v1}, Ljavax/microedition/khronos/egl/EGL10;->eglGetError()I

    move-result v1

    .line 827
    if-eq v1, v6, :cond_2

    .line 831
    :cond_2
    const/4 v1, 0x1

    iput-boolean v1, p0, Lcom/adobe/air/FlashEGL10;->mIsGPUOOM:Z

    .line 834
    :cond_3
    return v0
.end method


# virtual methods
.method public ChooseConfig(Ljavax/microedition/khronos/egl/EGLDisplay;[I[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z
    .locals 10

    .prologue
    .line 132
    invoke-virtual {p0}, Lcom/adobe/air/FlashEGL10;->IsEmulator()Z

    move-result v0

    if-nez v0, :cond_0

    .line 133
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move v4, p4

    move-object v5, p5

    invoke-interface/range {v0 .. v5}, Ljavax/microedition/khronos/egl/EGL10;->eglChooseConfig(Ljavax/microedition/khronos/egl/EGLDisplay;[I[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    move-result v0

    .line 181
    :goto_0
    return v0

    .line 137
    :cond_0
    const/4 v0, 0x1

    new-array v0, v0, [I

    .line 138
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-interface {v1, p1, v2, v3, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigs(Ljavax/microedition/khronos/egl/EGLDisplay;[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 139
    const/4 v1, 0x0

    aget v4, v0, v1

    .line 142
    new-array v5, v4, [Ljavax/microedition/khronos/egl/EGLConfig;

    .line 143
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    invoke-interface {v1, p1, v5, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigs(Ljavax/microedition/khronos/egl/EGLDisplay;[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 145
    const/4 v2, 0x0

    .line 146
    array-length v0, p2

    .line 147
    array-length v1, p2

    rem-int/lit8 v1, v1, 0x2

    if-eqz v1, :cond_1

    .line 148
    array-length v0, p2

    add-int/lit8 v0, v0, -0x1

    .line 150
    :cond_1
    const/4 v1, 0x0

    move v3, v1

    move v1, v2

    :goto_1
    if-ge v3, v4, :cond_6

    .line 152
    const/4 v2, 0x0

    .line 153
    :goto_2
    if-ge v2, v0, :cond_3

    .line 155
    add-int/lit8 v6, v2, 0x1

    aget v6, p2, v6

    const/4 v7, -0x1

    if-eq v6, v7, :cond_2

    .line 157
    const/4 v6, 0x1

    new-array v6, v6, [I

    .line 158
    iget-object v7, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    aget-object v8, v5, v3

    aget v9, p2, v2

    invoke-interface {v7, p1, v8, v9, v6}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 161
    const/4 v7, 0x0

    aget v6, v6, v7

    add-int/lit8 v7, v2, 0x1

    aget v7, p2, v7

    and-int/2addr v6, v7

    add-int/lit8 v7, v2, 0x1

    aget v7, p2, v7

    if-ne v6, v7, :cond_3

    .line 153
    :cond_2
    add-int/lit8 v2, v2, 0x2

    goto :goto_2

    .line 169
    :cond_3
    if-ne v2, v0, :cond_5

    .line 171
    if-eqz p3, :cond_4

    if-ge v1, p4, :cond_4

    .line 173
    aget-object v2, v5, v3

    aput-object v2, p3, v1

    .line 175
    :cond_4
    add-int/lit8 v1, v1, 0x1

    .line 150
    :cond_5
    add-int/lit8 v2, v3, 0x1

    move v3, v2

    goto :goto_1

    .line 180
    :cond_6
    const/4 v0, 0x0

    aput v1, p5, v0

    .line 181
    const/4 v0, 0x1

    goto :goto_0
.end method

.method public CreateDummySurfaceAndContext()I
    .locals 14

    .prologue
    const/4 v13, 0x3

    const/4 v12, 0x2

    const/16 v7, 0x3006

    const/4 v6, 0x0

    const/4 v4, 0x1

    .line 315
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_DISPLAY:Ljavax/microedition/khronos/egl/EGLDisplay;

    if-ne v0, v1, :cond_0

    .line 318
    const/16 v0, 0x3008

    .line 456
    :goto_0
    return v0

    .line 322
    :cond_0
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-eq v0, v1, :cond_3

    .line 324
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v0, v1, :cond_1

    .line 326
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v1, v2, v3, v4}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 328
    const/16 v0, 0x3000

    goto :goto_0

    .line 330
    :cond_1
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v0, v1, :cond_2

    .line 332
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v1, v2, v3, v4}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 334
    const/16 v0, 0x3000

    goto :goto_0

    .line 336
    :cond_2
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v3, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v5, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v1, v2, v3, v5}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 337
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v1, v2}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroyContext(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 338
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 342
    :cond_3
    new-array v5, v4, [I

    .line 343
    new-array v3, v4, [Ljavax/microedition/khronos/egl/EGLConfig;

    .line 344
    sget-object v0, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    aput v4, v0, v4

    .line 345
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v2, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    move-object v0, p0

    invoke-virtual/range {v0 .. v5}, Lcom/adobe/air/FlashEGL10;->ChooseConfig(Ljavax/microedition/khronos/egl/EGLDisplay;[I[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 346
    sget-object v0, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    const/4 v1, -0x1

    aput v1, v0, v4

    .line 348
    aget v0, v5, v6

    .line 349
    if-nez v0, :cond_4

    move v0, v7

    .line 351
    goto :goto_0

    .line 357
    :cond_4
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x12

    if-lt v0, v1, :cond_5

    move v0, v4

    .line 366
    :goto_1
    new-array v1, v13, [I

    sget v2, Lcom/adobe/air/FlashEGL10;->EGL_CONTEXT_CLIENT_VERSION:I

    aput v2, v1, v6

    aput v12, v1, v4

    const/16 v2, 0x3038

    aput v2, v1, v12

    .line 368
    if-eqz v0, :cond_f

    .line 370
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    aget-object v5, v3, v6

    sget-object v8, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v2, v5, v8, v1}, Ljavax/microedition/khronos/egl/EGL10;->eglCreateContext(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljavax/microedition/khronos/egl/EGLContext;[I)Ljavax/microedition/khronos/egl/EGLContext;

    move-result-object v0

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 371
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-ne v0, v2, :cond_6

    move v0, v7

    .line 374
    goto/16 :goto_0

    :cond_5
    move v0, v6

    .line 357
    goto :goto_1

    .line 376
    :cond_6
    const-string v0, "After creating dummy context for checking gl version"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 377
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    aget-object v5, v3, v6

    sget-object v8, Lcom/adobe/air/FlashEGL10;->fbPBufferSurfaceAttrs:[I

    invoke-interface {v0, v2, v5, v8}, Ljavax/microedition/khronos/egl/EGL10;->eglCreatePbufferSurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;[I)Ljavax/microedition/khronos/egl/EGLSurface;

    move-result-object v2

    .line 378
    const-string v0, "After eglCreatePbufferSurface for checking gl version"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 379
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-ne v2, v0, :cond_7

    move v0, v7

    .line 382
    goto/16 :goto_0

    .line 384
    :cond_7
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v5, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v8, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v5, v2, v2, v8}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 385
    const-string v0, "After eglMakeCurrent for checking gl version"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 386
    const/16 v0, 0x1f02

    invoke-static {v0}, Landroid/opengl/GLES10;->glGetString(I)Ljava/lang/String;

    move-result-object v0

    .line 388
    if-eqz v0, :cond_e

    .line 389
    new-instance v5, Ljava/util/Scanner;

    invoke-direct {v5, v0}, Ljava/util/Scanner;-><init>(Ljava/lang/String;)V

    .line 390
    const-string v0, "[^\\w\']+"

    invoke-virtual {v5, v0}, Ljava/util/Scanner;->useDelimiter(Ljava/lang/String;)Ljava/util/Scanner;

    .line 392
    :cond_8
    :goto_2
    invoke-virtual {v5}, Ljava/util/Scanner;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_e

    .line 393
    invoke-virtual {v5}, Ljava/util/Scanner;->hasNextInt()Z

    move-result v0

    if-eqz v0, :cond_a

    .line 394
    invoke-virtual {v5}, Ljava/util/Scanner;->nextInt()I

    move-result v0

    .line 402
    :goto_3
    if-lt v0, v13, :cond_d

    move v0, v4

    .line 408
    :goto_4
    iget-object v5, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v8, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v9, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v10, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v11, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v5, v8, v9, v10, v11}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 410
    iget-object v5, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v8, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    invoke-interface {v5, v8, v2}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroySurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z

    .line 411
    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v5, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v8, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v2, v5, v8}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroyContext(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 412
    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    iput-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 415
    :goto_5
    if-eqz v0, :cond_9

    .line 418
    aput v13, v1, v4

    .line 419
    const-string v0, "Before eglCreateContext es3"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 421
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    aget-object v5, v3, v6

    sget-object v8, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v2, v5, v8, v1}, Ljavax/microedition/khronos/egl/EGL10;->eglCreateContext(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljavax/microedition/khronos/egl/EGLContext;[I)Ljavax/microedition/khronos/egl/EGLContext;

    move-result-object v0

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 422
    const-string v0, "After eglCreateContext es3"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 423
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-eq v0, v2, :cond_9

    .line 424
    iput-boolean v4, p0, Lcom/adobe/air/FlashEGL10;->mIsES3Device:Z

    .line 428
    :cond_9
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-ne v0, v2, :cond_b

    .line 430
    aput v12, v1, v4

    .line 431
    const-string v0, "Before eglCreateContext es2"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 432
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    aget-object v4, v3, v6

    sget-object v5, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v2, v4, v5, v1}, Ljavax/microedition/khronos/egl/EGL10;->eglCreateContext(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljavax/microedition/khronos/egl/EGLContext;[I)Ljavax/microedition/khronos/egl/EGLContext;

    move-result-object v0

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 433
    const-string v0, "After eglCreateContext es2"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 434
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-ne v0, v1, :cond_b

    move v0, v7

    .line 437
    goto/16 :goto_0

    .line 397
    :cond_a
    invoke-virtual {v5}, Ljava/util/Scanner;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_8

    .line 398
    invoke-virtual {v5}, Ljava/util/Scanner;->next()Ljava/lang/String;

    goto/16 :goto_2

    .line 441
    :cond_b
    const-string v0, "Before eglCreatePbufferSurface"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 442
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    aget-object v2, v3, v6

    sget-object v3, Lcom/adobe/air/FlashEGL10;->fbPBufferSurfaceAttrs:[I

    invoke-interface {v0, v1, v2, v3}, Ljavax/microedition/khronos/egl/EGL10;->eglCreatePbufferSurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;[I)Ljavax/microedition/khronos/egl/EGLSurface;

    move-result-object v0

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 443
    const-string v0, "After eglCreatePbufferSurface"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 445
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-ne v0, v1, :cond_c

    move v0, v7

    .line 448
    goto/16 :goto_0

    .line 451
    :cond_c
    const-string v0, "Before eglMakeCurrent"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 452
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v1, v2, v3, v4}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 453
    const-string v0, "After eglMakeCurrent"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 456
    const/16 v0, 0x3000

    goto/16 :goto_0

    :cond_d
    move v0, v6

    goto/16 :goto_4

    :cond_e
    move v0, v6

    goto/16 :goto_3

    :cond_f
    move v0, v6

    goto/16 :goto_5
.end method

.method public CreateGLContext(Z)I
    .locals 6

    .prologue
    const/16 v3, 0x3000

    const/4 v1, 0x3

    const/4 v2, 0x2

    .line 519
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    if-nez v0, :cond_0

    .line 522
    const/16 v0, 0x3005

    .line 565
    :goto_0
    return v0

    .line 527
    :cond_0
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v4, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-eq v0, v4, :cond_1

    if-nez p1, :cond_1

    move v0, v3

    .line 529
    goto :goto_0

    .line 535
    :cond_1
    iget-boolean v0, p0, Lcom/adobe/air/FlashEGL10;->mIsES3Device:Z

    if-eqz v0, :cond_2

    move v0, v1

    .line 536
    :goto_1
    new-array v1, v1, [I

    const/4 v4, 0x0

    sget v5, Lcom/adobe/air/FlashEGL10;->EGL_CONTEXT_CLIENT_VERSION:I

    aput v5, v1, v4

    const/4 v4, 0x1

    aput v0, v1, v4

    const/16 v0, 0x3038

    aput v0, v1, v2

    .line 538
    if-eqz p1, :cond_3

    .line 540
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 541
    const-string v2, "Before eglCreateContext"

    invoke-direct {p0, v2}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 542
    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v5, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    invoke-interface {v2, v4, v5, v0, v1}, Ljavax/microedition/khronos/egl/EGL10;->eglCreateContext(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljavax/microedition/khronos/egl/EGLContext;[I)Ljavax/microedition/khronos/egl/EGLContext;

    move-result-object v1

    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 543
    const-string v1, "After eglCreateContext"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 544
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    invoke-interface {v1, v2, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroyContext(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 545
    const-string v0, "After eglDestroyContext"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 554
    :goto_2
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-ne v0, v1, :cond_4

    .line 555
    const/16 v0, 0x3006

    goto :goto_0

    :cond_2
    move v0, v2

    .line 535
    goto :goto_1

    .line 549
    :cond_3
    const-string v0, "Before eglCreateContext"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 550
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    sget-object v5, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v2, v4, v5, v1}, Ljavax/microedition/khronos/egl/EGL10;->eglCreateContext(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljavax/microedition/khronos/egl/EGLContext;[I)Ljavax/microedition/khronos/egl/EGLContext;

    move-result-object v0

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 551
    const-string v0, "After eglCreateContext"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    goto :goto_2

    .line 558
    :cond_4
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    if-ne v0, v1, :cond_5

    .line 560
    const-string v0, "Before eglCreatePbufferSurface"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 561
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    sget-object v4, Lcom/adobe/air/FlashEGL10;->fbPBufferSurfaceAttrs:[I

    invoke-interface {v0, v1, v2, v4}, Ljavax/microedition/khronos/egl/EGL10;->eglCreatePbufferSurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;[I)Ljavax/microedition/khronos/egl/EGLSurface;

    move-result-object v0

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 562
    const-string v0, "After eglCreatePbufferSurface"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    :cond_5
    move v0, v3

    .line 565
    goto/16 :goto_0
.end method

.method public CreateWindowSurface(Landroid/view/SurfaceView;I)I
    .locals 10

    .prologue
    const/16 v0, 0x300d

    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 665
    iget-boolean v1, p0, Lcom/adobe/air/FlashEGL10;->mIsGPUOOM:Z

    if-eqz v1, :cond_1

    .line 666
    const/16 v0, 0x3003

    .line 749
    :cond_0
    :goto_0
    return v0

    .line 668
    :cond_1
    instance-of v5, p1, Lcom/adobe/air/AIRWindowSurfaceView;

    .line 670
    instance-of v1, p1, Lcom/adobe/flashruntime/air/VideoViewAIR;

    if-nez v1, :cond_2

    instance-of v1, p1, Lcom/adobe/air/AIRStage3DSurfaceView;

    if-nez v1, :cond_2

    if-eqz v5, :cond_0

    .line 678
    :cond_2
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v4, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v1, v4, :cond_3

    .line 681
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 682
    invoke-virtual {p0}, Lcom/adobe/air/FlashEGL10;->MakeGLCurrent()I

    move-result v0

    goto :goto_0

    .line 687
    :cond_3
    iget v1, p0, Lcom/adobe/air/FlashEGL10;->kSwapPreserveOn:I

    if-ne p2, v1, :cond_4

    .line 689
    const-string v1, "Before eglCreateWindowSurface"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 690
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v6, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    invoke-virtual {p1}, Landroid/view/SurfaceView;->getHolder()Landroid/view/SurfaceHolder;

    move-result-object v7

    sget-object v8, Lcom/adobe/air/FlashEGL10;->fbWindowSurfaceOnAttrs:[I

    invoke-interface {v1, v4, v6, v7, v8}, Ljavax/microedition/khronos/egl/EGL10;->eglCreateWindowSurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljava/lang/Object;[I)Ljavax/microedition/khronos/egl/EGLSurface;

    move-result-object v1

    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 691
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v4, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-ne v1, v4, :cond_9

    .line 692
    const-string v1, "After eglCreateWindowSurface"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    move v1, v2

    .line 704
    :goto_1
    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v6, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-ne v4, v6, :cond_5

    .line 707
    const-string v4, "Before eglCreateWindowSurface"

    invoke-direct {p0, v4}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 708
    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v6, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v7, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    invoke-virtual {p1}, Landroid/view/SurfaceView;->getHolder()Landroid/view/SurfaceHolder;

    move-result-object v8

    const/4 v9, 0x0

    invoke-interface {v4, v6, v7, v8, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglCreateWindowSurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljava/lang/Object;[I)Ljavax/microedition/khronos/egl/EGLSurface;

    move-result-object v4

    iput-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 709
    const-string v4, "After eglCreateWindowSurface"

    invoke-direct {p0, v4}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    move-result v4

    .line 710
    const/16 v6, 0x3000

    if-eq v4, v6, :cond_5

    move v0, v4

    .line 711
    goto :goto_0

    .line 695
    :cond_4
    iget v1, p0, Lcom/adobe/air/FlashEGL10;->kSwapPreserveOff:I

    if-ne p2, v1, :cond_9

    .line 697
    const-string v1, "Before eglCreateWindowSurface"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 698
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v6, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    invoke-virtual {p1}, Landroid/view/SurfaceView;->getHolder()Landroid/view/SurfaceHolder;

    move-result-object v7

    sget-object v8, Lcom/adobe/air/FlashEGL10;->fbWindowSurfaceOffAttrs:[I

    invoke-interface {v1, v4, v6, v7, v8}, Ljavax/microedition/khronos/egl/EGL10;->eglCreateWindowSurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljava/lang/Object;[I)Ljavax/microedition/khronos/egl/EGLSurface;

    move-result-object v1

    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 699
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v4, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-ne v1, v4, :cond_9

    .line 700
    const-string v1, "After eglCreateWindowSurface"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    move v1, v2

    .line 701
    goto :goto_1

    .line 714
    :cond_5
    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v6, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v4, v6, :cond_0

    .line 722
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 724
    if-eqz v5, :cond_6

    move-object v0, p1

    .line 726
    check-cast v0, Lcom/adobe/air/AIRWindowSurfaceView;

    invoke-virtual {v0, p0}, Lcom/adobe/air/AIRWindowSurfaceView;->setFlashEGL(Lcom/adobe/air/FlashEGL;)V

    .line 730
    check-cast p1, Lcom/adobe/air/AIRWindowSurfaceView;

    invoke-virtual {p1}, Lcom/adobe/air/AIRWindowSurfaceView;->getActivityWrapper()Lcom/adobe/air/AndroidActivityWrapper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/adobe/air/AndroidActivityWrapper;->getActivity()Landroid/app/Activity;

    move-result-object v0

    .line 731
    if-eqz v0, :cond_6

    .line 734
    invoke-virtual {v0}, Landroid/app/Activity;->getWindow()Landroid/view/Window;

    move-result-object v0

    .line 735
    const/16 v4, 0x22

    invoke-virtual {v0, v4}, Landroid/view/Window;->setSoftInputMode(I)V

    .line 739
    :cond_6
    new-array v0, v3, [I

    .line 740
    aput v2, v0, v2

    .line 741
    iput-boolean v2, p0, Lcom/adobe/air/FlashEGL10;->mIsBufferPreserve:Z

    .line 742
    if-eqz v1, :cond_7

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v5, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget v6, Lcom/adobe/air/FlashEGL10;->EGL_SWAP_BEHAVIOR:I

    invoke-interface {v1, v4, v5, v6, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglQuerySurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;I[I)Z

    move-result v1

    if-eqz v1, :cond_7

    .line 743
    aget v0, v0, v2

    sget v1, Lcom/adobe/air/FlashEGL10;->EGL_BUFFER_PRESERVED:I

    if-ne v0, v1, :cond_8

    :goto_2
    iput-boolean v3, p0, Lcom/adobe/air/FlashEGL10;->mIsBufferPreserve:Z

    .line 749
    :cond_7
    invoke-virtual {p0}, Lcom/adobe/air/FlashEGL10;->MakeGLCurrent()I

    move-result v0

    goto/16 :goto_0

    :cond_8
    move v3, v2

    .line 743
    goto :goto_2

    :cond_9
    move v1, v3

    goto/16 :goto_1
.end method

.method public DestroyGLContext()Z
    .locals 5

    .prologue
    .line 495
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-eq v0, v1, :cond_0

    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_DISPLAY:Ljavax/microedition/khronos/egl/EGLDisplay;

    if-ne v0, v1, :cond_1

    .line 497
    :cond_0
    const/4 v0, 0x0

    .line 513
    :goto_0
    return v0

    .line 500
    :cond_1
    const-string v0, "DestroyGLContext: Before eglMakeCurrent for noSurface"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 501
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v3, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v4, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v1, v2, v3, v4}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 502
    const-string v0, "DestroyGLContext: After eglMakeCurrent"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 504
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v0, v1, :cond_2

    .line 505
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    invoke-interface {v0, v1, v2}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroySurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z

    .line 506
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 509
    :cond_2
    const-string v0, "Before eglDestroyContext"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 510
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v1, v2}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroyContext(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLContext;)Z

    move-result v0

    .line 511
    const-string v1, "After eglDestroyContext"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 512
    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    goto :goto_0
.end method

.method public DestroyWindowSurface()Z
    .locals 7

    .prologue
    const/16 v6, 0x3000

    const/4 v0, 0x0

    .line 754
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v1, v2, :cond_0

    .line 757
    const-string v1, "Before eglMakeCurrent"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 758
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v3, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v4, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v5, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v1, v2, v3, v4, v5}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 760
    const-string v1, "After eglMakeCurrent"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    move-result v1

    if-eq v6, v1, :cond_1

    .line 782
    :cond_0
    :goto_0
    return v0

    .line 763
    :cond_1
    const-string v1, "Before eglDestroySurface (window)"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 764
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    invoke-interface {v1, v2, v3}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroySurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z

    .line 765
    const-string v1, "After eglDestroySurface (window)"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    move-result v1

    if-ne v6, v1, :cond_0

    .line 768
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    if-ne v1, v2, :cond_2

    .line 769
    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 770
    :cond_2
    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 772
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v1, v2, :cond_3

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-eq v1, v2, :cond_3

    .line 774
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 775
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v5, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v1, v2, v3, v4, v5}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 776
    const-string v1, "After eglMakeCurrent"

    invoke-direct {p0, v1}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    move-result v1

    if-ne v6, v1, :cond_0

    .line 780
    :cond_3
    const/4 v0, 0x1

    goto :goto_0
.end method

.method public FlashEGL10()V
    .locals 2

    .prologue
    const/4 v1, 0x0

    .line 84
    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    .line 85
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_DISPLAY:Ljavax/microedition/khronos/egl/EGLDisplay;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    .line 86
    iput-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    .line 87
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 88
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 89
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 90
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 91
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/adobe/air/FlashEGL10;->mIsARGBSurface:Z

    .line 92
    return-void
.end method

.method public GetConfigs(ZZ)[I
    .locals 10

    .prologue
    const/4 v6, 0x1

    const/4 v7, 0x0

    .line 220
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigCount:I

    iget v1, p0, Lcom/adobe/air/FlashEGL10;->kNumElements:I

    mul-int/2addr v0, v1

    new-array v8, v0, [I

    .line 221
    new-array v5, v6, [I

    .line 222
    new-array v9, v6, [I

    .line 225
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigCount:I

    new-array v0, v0, [Ljavax/microedition/khronos/egl/EGLConfig;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    .line 227
    const-string v0, "Before eglChooseConfig"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 228
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v2, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    iget v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigCount:I

    move-object v0, p0

    invoke-virtual/range {v0 .. v5}, Lcom/adobe/air/FlashEGL10;->ChooseConfig(Ljavax/microedition/khronos/egl/EGLDisplay;[I[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 229
    const-string v0, "After eglChooseConfig"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 231
    aget v2, v5, v7

    iput v2, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigCount:I

    move v1, v7

    .line 232
    :goto_0
    if-ge v1, v2, :cond_5

    .line 234
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v4, v4, v1

    const/16 v5, 0x3033

    invoke-interface {v0, v3, v4, v5, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 235
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kSurfaceTypes:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v3, v9, v7

    aput v3, v8, v0

    .line 237
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kConfigId:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aput v1, v8, v0

    .line 239
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v4, v4, v1

    const/16 v5, 0x3024

    invoke-interface {v0, v3, v4, v5, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 240
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kRedBits:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v3, v9, v7

    aput v3, v8, v0

    .line 242
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v4, v4, v1

    const/16 v5, 0x3023

    invoke-interface {v0, v3, v4, v5, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 243
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kGreenBits:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v3, v9, v7

    aput v3, v8, v0

    .line 245
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v4, v4, v1

    const/16 v5, 0x3022

    invoke-interface {v0, v3, v4, v5, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 246
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kBlueBits:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v3, v9, v7

    aput v3, v8, v0

    .line 248
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v4, v4, v1

    const/16 v5, 0x3021

    invoke-interface {v0, v3, v4, v5, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 249
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kAlphaBits:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v3, v9, v7

    aput v3, v8, v0

    .line 251
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v4, v4, v1

    const/16 v5, 0x3020

    invoke-interface {v0, v3, v4, v5, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 252
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kColorBits:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v3, v9, v7

    aput v3, v8, v0

    .line 254
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v4, v4, v1

    const/16 v5, 0x3025

    invoke-interface {v0, v3, v4, v5, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 255
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kDepthBits:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v3, v9, v7

    aput v3, v8, v0

    .line 257
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v4, v4, v1

    const/16 v5, 0x3026

    invoke-interface {v0, v3, v4, v5, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 258
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kStencilBits:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v3, v9, v7

    aput v3, v8, v0

    .line 260
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kCsaaSamp:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aput v7, v8, v0

    .line 261
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kMsaaSamp:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aput v7, v8, v0

    .line 263
    if-eqz p1, :cond_2

    .line 264
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v4, v4, v1

    sget v5, Lcom/adobe/air/FlashEGL10;->EGL_COVERAGE_SAMPLES_NV:I

    invoke-interface {v0, v3, v4, v5, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 265
    aget v0, v9, v7

    if-eq v0, v6, :cond_0

    .line 266
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kCsaaSamp:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v3, v9, v7

    aput v3, v8, v0

    .line 274
    :cond_0
    :goto_1
    if-eqz p2, :cond_4

    .line 276
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kSwapPreserve:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v3

    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglVersion:[I

    aget v0, v0, v7

    if-gt v0, v6, :cond_1

    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglVersion:[I

    aget v0, v0, v6

    const/4 v4, 0x3

    if-le v0, v4, :cond_3

    :cond_1
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kSurfaceTypes:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v0, v8, v0

    sget v4, Lcom/adobe/air/FlashEGL10;->EGL_BUFFER_PRESERVED:I

    and-int/2addr v0, v4

    if-eqz v0, :cond_3

    move v0, v6

    :goto_2
    aput v0, v8, v3

    .line 232
    :goto_3
    add-int/lit8 v0, v1, 0x1

    move v1, v0

    goto/16 :goto_0

    .line 269
    :cond_2
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v4, v4, v1

    const/16 v5, 0x3031

    invoke-interface {v0, v3, v4, v5, v9}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 270
    aget v0, v9, v7

    if-eq v0, v6, :cond_0

    .line 271
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kMsaaSamp:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aget v3, v9, v7

    aput v3, v8, v0

    goto :goto_1

    :cond_3
    move v0, v7

    .line 276
    goto :goto_2

    .line 279
    :cond_4
    iget v0, p0, Lcom/adobe/air/FlashEGL10;->kSwapPreserve:I

    invoke-direct {p0, v1, v0}, Lcom/adobe/air/FlashEGL10;->XX(II)I

    move-result v0

    aput v7, v8, v0

    goto :goto_3

    .line 282
    :cond_5
    return-object v8
.end method

.method public GetNumConfigs()[I
    .locals 10

    .prologue
    const/4 v9, 0x4

    const/4 v8, 0x2

    const/4 v3, 0x0

    const/4 v7, 0x1

    const/4 v4, 0x0

    .line 186
    new-array v6, v9, [I

    .line 187
    new-array v5, v7, [I

    .line 190
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v2, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    move-object v0, p0

    invoke-virtual/range {v0 .. v5}, Lcom/adobe/air/FlashEGL10;->ChooseConfig(Ljavax/microedition/khronos/egl/EGLDisplay;[I[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 191
    aget v0, v5, v4

    aput v0, v6, v4

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigCount:I

    .line 195
    sget-object v0, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    aput v9, v0, v7

    .line 196
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v2, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    move-object v0, p0

    invoke-virtual/range {v0 .. v5}, Lcom/adobe/air/FlashEGL10;->ChooseConfig(Ljavax/microedition/khronos/egl/EGLDisplay;[I[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 197
    aget v0, v5, v4

    aput v0, v6, v7

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->mWindowConfigCount:I

    .line 201
    sget-object v0, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    aput v8, v0, v7

    .line 202
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v2, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    move-object v0, p0

    invoke-virtual/range {v0 .. v5}, Lcom/adobe/air/FlashEGL10;->ChooseConfig(Ljavax/microedition/khronos/egl/EGLDisplay;[I[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 203
    aget v0, v5, v4

    aput v0, v6, v8

    iput v0, p0, Lcom/adobe/air/FlashEGL10;->mPixmapConfigCount:I

    .line 207
    sget-object v0, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    aput v7, v0, v7

    .line 208
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v2, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    move-object v0, p0

    invoke-virtual/range {v0 .. v5}, Lcom/adobe/air/FlashEGL10;->ChooseConfig(Ljavax/microedition/khronos/egl/EGLDisplay;[I[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 209
    const/4 v0, 0x3

    aget v1, v5, v4

    aput v1, v6, v0

    iput v1, p0, Lcom/adobe/air/FlashEGL10;->mPbufferConfigCount:I

    .line 213
    sget-object v0, Lcom/adobe/air/FlashEGL10;->cfgAttrs:[I

    const/4 v1, -0x1

    aput v1, v0, v7

    .line 215
    return-object v6
.end method

.method public GetSurfaceHeight()I
    .locals 5

    .prologue
    .line 117
    const/4 v0, 0x1

    new-array v0, v0, [I

    .line 118
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    const/16 v4, 0x3056

    invoke-interface {v1, v2, v3, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglQuerySurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;I[I)Z

    .line 120
    const/4 v1, 0x0

    aget v0, v0, v1

    return v0
.end method

.method public GetSurfaceWidth()I
    .locals 5

    .prologue
    .line 109
    const/4 v0, 0x1

    new-array v0, v0, [I

    .line 110
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    const/16 v4, 0x3057

    invoke-interface {v1, v2, v3, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglQuerySurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;I[I)Z

    .line 112
    const/4 v1, 0x0

    aget v0, v0, v1

    return v0
.end method

.method public HasGLContext()Z
    .locals 2

    .prologue
    .line 104
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-eq v0, v1, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public InitEGL()I
    .locals 4

    .prologue
    const/16 v1, 0x3000

    .line 462
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-eq v0, v2, :cond_1

    move v0, v1

    .line 490
    :cond_0
    :goto_0
    return v0

    .line 469
    :cond_1
    invoke-static {}, Ljavax/microedition/khronos/egl/EGLContext;->getEGL()Ljavax/microedition/khronos/egl/EGL;

    move-result-object v0

    check-cast v0, Ljavax/microedition/khronos/egl/EGL10;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    .line 473
    const-string v0, "Before eglGetDisplay"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 474
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_DEFAULT_DISPLAY:Ljava/lang/Object;

    invoke-interface {v0, v2}, Ljavax/microedition/khronos/egl/EGL10;->eglGetDisplay(Ljava/lang/Object;)Ljavax/microedition/khronos/egl/EGLDisplay;

    move-result-object v0

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    .line 475
    const-string v0, "After eglGetDisplay"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    move-result v0

    .line 476
    if-ne v1, v0, :cond_0

    .line 481
    const/4 v0, 0x2

    new-array v0, v0, [I

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglVersion:[I

    .line 482
    const-string v0, "Before eglInitialize"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 483
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglVersion:[I

    invoke-interface {v0, v2, v3}, Ljavax/microedition/khronos/egl/EGL10;->eglInitialize(Ljavax/microedition/khronos/egl/EGLDisplay;[I)Z

    .line 484
    const-string v0, "After eglInitialize"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    move-result v0

    .line 485
    if-ne v1, v0, :cond_0

    move v0, v1

    .line 490
    goto :goto_0
.end method

.method public IsARGBSurface()Z
    .locals 1

    .prologue
    .line 787
    iget-boolean v0, p0, Lcom/adobe/air/FlashEGL10;->mIsARGBSurface:Z

    return v0
.end method

.method public IsBufferPreserve()Z
    .locals 1

    .prologue
    .line 792
    iget-boolean v0, p0, Lcom/adobe/air/FlashEGL10;->mIsBufferPreserve:Z

    return v0
.end method

.method public IsEmulator()Z
    .locals 2

    .prologue
    .line 125
    sget-object v0, Landroid/os/Build;->BRAND:Ljava/lang/String;

    const-string v1, "generic"

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    sget-object v0, Landroid/os/Build;->DEVICE:Ljava/lang/String;

    const-string v1, "generic"

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public MakeGLCurrent()I
    .locals 5

    .prologue
    .line 638
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-ne v0, v1, :cond_0

    .line 641
    const/16 v0, 0x3006

    .line 658
    :goto_0
    return v0

    .line 644
    :cond_0
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-ne v0, v1, :cond_1

    .line 647
    const/16 v0, 0x300d

    goto :goto_0

    .line 650
    :cond_1
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_DISPLAY:Ljavax/microedition/khronos/egl/EGLDisplay;

    if-ne v0, v1, :cond_2

    .line 653
    const/16 v0, 0x3008

    goto :goto_0

    .line 656
    :cond_2
    const-string v0, "Before eglMakeCurrent"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 657
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    iget-object v4, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v1, v2, v3, v4}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 658
    const-string v0, "After eglMakeCurrent"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    move-result v0

    goto :goto_0
.end method

.method public ReleaseGPUResources()V
    .locals 5

    .prologue
    .line 583
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    if-ne v0, v1, :cond_0

    .line 621
    :goto_0
    return-void

    .line 589
    :cond_0
    const-string v0, "Before eglMakeCurrent"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 590
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v3, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v4, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v1, v2, v3, v4}, Ljavax/microedition/khronos/egl/EGL10;->eglMakeCurrent(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 591
    const-string v0, "After eglMakeCurrent"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 594
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    monitor-enter v1

    .line 596
    :try_start_0
    const-string v0, "Before eglDestroySurface"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 597
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v2, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v0, v2, :cond_1

    .line 598
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    invoke-interface {v0, v2, v3}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroySurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z

    .line 599
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglWindowSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 601
    :cond_1
    const-string v0, "After eglDestroySurface (window)"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 602
    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 604
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    if-eq v0, v1, :cond_2

    .line 606
    const-string v0, "Before eglDestroySurface (pbuffer)"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 607
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    invoke-interface {v0, v1, v2}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroySurface(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z

    .line 608
    const-string v0, "After eglDestroySurface (pbuffer)"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 609
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglPbufferSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    .line 613
    :cond_2
    const-string v0, "Before eglDestroyContext"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 614
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    invoke-interface {v0, v1, v2}, Ljavax/microedition/khronos/egl/EGL10;->eglDestroyContext(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLContext;)Z

    .line 615
    const-string v0, "After eglDestroyContext"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 617
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_CONTEXT:Ljavax/microedition/khronos/egl/EGLContext;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglContext:Ljavax/microedition/khronos/egl/EGLContext;

    .line 618
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_SURFACE:Ljavax/microedition/khronos/egl/EGLSurface;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    goto :goto_0

    .line 602
    :catchall_0
    move-exception v0

    :try_start_1
    monitor-exit v1
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method

.method public SetConfig(I)V
    .locals 6

    .prologue
    const/4 v5, 0x0

    .line 288
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglConfigList:[Ljavax/microedition/khronos/egl/EGLConfig;

    aget-object v0, v0, p1

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    .line 290
    const/4 v0, 0x1

    new-array v0, v0, [I

    .line 291
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    const/16 v4, 0x3024

    invoke-interface {v1, v2, v3, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 292
    aget v1, v0, v5

    .line 293
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    const/16 v4, 0x3023

    invoke-interface {v1, v2, v3, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 294
    aget v1, v0, v5

    .line 295
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    const/16 v4, 0x3022

    invoke-interface {v1, v2, v3, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 296
    aget v1, v0, v5

    .line 297
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    const/16 v4, 0x3021

    invoke-interface {v1, v2, v3, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 298
    aget v1, v0, v5

    .line 299
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    const/16 v4, 0x3025

    invoke-interface {v1, v2, v3, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 300
    aget v1, v0, v5

    .line 301
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    const/16 v4, 0x3026

    invoke-interface {v1, v2, v3, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 302
    aget v1, v0, v5

    .line 303
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    const/16 v4, 0x3031

    invoke-interface {v1, v2, v3, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 304
    aget v1, v0, v5

    .line 305
    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v3, p0, Lcom/adobe/air/FlashEGL10;->mEglConfig:Ljavax/microedition/khronos/egl/EGLConfig;

    const/16 v4, 0x3032

    invoke-interface {v1, v2, v3, v4, v0}, Ljavax/microedition/khronos/egl/EGL10;->eglGetConfigAttrib(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z

    .line 306
    aget v0, v0, v5

    .line 309
    return-void
.end method

.method public SwapEGLBuffers()V
    .locals 3

    .prologue
    .line 627
    const/16 v0, 0x3000

    invoke-virtual {p0}, Lcom/adobe/air/FlashEGL10;->MakeGLCurrent()I

    move-result v1

    if-eq v0, v1, :cond_0

    .line 634
    :goto_0
    return-void

    .line 631
    :cond_0
    const-string v0, "Before eglSwapBuffers"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    .line 632
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    iget-object v2, p0, Lcom/adobe/air/FlashEGL10;->mEglSurface:Ljavax/microedition/khronos/egl/EGLSurface;

    invoke-interface {v0, v1, v2}, Ljavax/microedition/khronos/egl/EGL10;->eglSwapBuffers(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z

    .line 633
    const-string v0, "After eglSwapBuffers"

    invoke-direct {p0, v0}, Lcom/adobe/air/FlashEGL10;->checkEglError(Ljava/lang/String;)I

    goto :goto_0
.end method

.method public TerminateEGL()V
    .locals 2

    .prologue
    .line 570
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    sget-object v1, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_DISPLAY:Ljavax/microedition/khronos/egl/EGLDisplay;

    if-eq v0, v1, :cond_0

    .line 573
    iget-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEgl:Ljavax/microedition/khronos/egl/EGL10;

    iget-object v1, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    invoke-interface {v0, v1}, Ljavax/microedition/khronos/egl/EGL10;->eglTerminate(Ljavax/microedition/khronos/egl/EGLDisplay;)Z

    .line 575
    :cond_0
    sget-object v0, Ljavax/microedition/khronos/egl/EGL10;->EGL_NO_DISPLAY:Ljavax/microedition/khronos/egl/EGLDisplay;

    iput-object v0, p0, Lcom/adobe/air/FlashEGL10;->mEglDisplay:Ljavax/microedition/khronos/egl/EGLDisplay;

    .line 576
    return-void
.end method
