.class public Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/google/android/gms/common/internal/safeparcel/SafeParcelable;


# static fields
.field public static final CREATOR:Landroid/os/Parcelable$Creator;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Landroid/os/Parcelable$Creator",
            "<",
            "Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private final mPendingIntent:Landroid/app/PendingIntent;

.field private final mVersionCode:I

.field private final zzasF:Lcom/google/android/gms/fitness/data/zzj;

.field private final zzasb:Lcom/google/android/gms/internal/zzoj;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    new-instance v0, Lcom/google/android/gms/fitness/request/zzt;

    invoke-direct {v0}, Lcom/google/android/gms/fitness/request/zzt;-><init>()V

    sput-object v0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->CREATOR:Landroid/os/Parcelable$Creator;

    return-void
.end method

.method constructor <init>(ILandroid/os/IBinder;Landroid/app/PendingIntent;Landroid/os/IBinder;)V
    .locals 1
    .param p1, "versionCode"    # I
    .param p2, "listenerBinder"    # Landroid/os/IBinder;
    .param p3, "pendingIntent"    # Landroid/app/PendingIntent;
    .param p4, "callback"    # Landroid/os/IBinder;

    .prologue
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput p1, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->mVersionCode:I

    if-nez p2, :cond_0

    const/4 v0, 0x0

    :goto_0
    iput-object v0, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->zzasF:Lcom/google/android/gms/fitness/data/zzj;

    iput-object p3, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->mPendingIntent:Landroid/app/PendingIntent;

    invoke-static {p4}, Lcom/google/android/gms/internal/zzoj$zza;->zzbJ(Landroid/os/IBinder;)Lcom/google/android/gms/internal/zzoj;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->zzasb:Lcom/google/android/gms/internal/zzoj;

    return-void

    :cond_0
    invoke-static {p2}, Lcom/google/android/gms/fitness/data/zzj$zza;->zzbl(Landroid/os/IBinder;)Lcom/google/android/gms/fitness/data/zzj;

    move-result-object v0

    goto :goto_0
.end method

.method public constructor <init>(Lcom/google/android/gms/fitness/data/zzj;Landroid/app/PendingIntent;Lcom/google/android/gms/internal/zzoj;)V
    .locals 1
    .param p1, "listener"    # Lcom/google/android/gms/fitness/data/zzj;
    .param p2, "pendingIntent"    # Landroid/app/PendingIntent;
    .param p3, "callback"    # Lcom/google/android/gms/internal/zzoj;

    .prologue
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x4

    iput v0, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->mVersionCode:I

    iput-object p1, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->zzasF:Lcom/google/android/gms/fitness/data/zzj;

    iput-object p2, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->mPendingIntent:Landroid/app/PendingIntent;

    iput-object p3, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->zzasb:Lcom/google/android/gms/internal/zzoj;

    return-void
.end method


# virtual methods
.method public describeContents()I
    .locals 1

    const/4 v0, 0x0

    return v0
.end method

.method getVersionCode()I
    .locals 1

    iget v0, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->mVersionCode:I

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 4

    const-string v0, "SensorUnregistrationRequest{%s}"

    const/4 v1, 0x1

    new-array v1, v1, [Ljava/lang/Object;

    const/4 v2, 0x0

    iget-object v3, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->zzasF:Lcom/google/android/gms/fitness/data/zzj;

    aput-object v3, v1, v2

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public writeToParcel(Landroid/os/Parcel;I)V
    .locals 0
    .param p1, "parcel"    # Landroid/os/Parcel;
    .param p2, "flags"    # I

    .prologue
    invoke-static {p0, p1, p2}, Lcom/google/android/gms/fitness/request/zzt;->zza(Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;Landroid/os/Parcel;I)V

    return-void
.end method

.method public zzsO()Landroid/os/IBinder;
    .locals 1

    iget-object v0, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->zzasb:Lcom/google/android/gms/internal/zzoj;

    if-nez v0, :cond_0

    const/4 v0, 0x0

    :goto_0
    return-object v0

    :cond_0
    iget-object v0, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->zzasb:Lcom/google/android/gms/internal/zzoj;

    invoke-interface {v0}, Lcom/google/android/gms/internal/zzoj;->asBinder()Landroid/os/IBinder;

    move-result-object v0

    goto :goto_0
.end method

.method public zzta()Landroid/app/PendingIntent;
    .locals 1

    iget-object v0, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->mPendingIntent:Landroid/app/PendingIntent;

    return-object v0
.end method

.method zztf()Landroid/os/IBinder;
    .locals 1

    iget-object v0, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->zzasF:Lcom/google/android/gms/fitness/data/zzj;

    if-nez v0, :cond_0

    const/4 v0, 0x0

    :goto_0
    return-object v0

    :cond_0
    iget-object v0, p0, Lcom/google/android/gms/fitness/request/SensorUnregistrationRequest;->zzasF:Lcom/google/android/gms/fitness/data/zzj;

    invoke-interface {v0}, Lcom/google/android/gms/fitness/data/zzj;->asBinder()Landroid/os/IBinder;

    move-result-object v0

    goto :goto_0
.end method
