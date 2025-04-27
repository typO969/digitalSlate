.class public abstract Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;
.super Landroid/app/Service;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zza;,
        Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zzb;,
        Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;,
        Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;
    }
.end annotation


# static fields
.field private static zzVF:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;

.field private static final zzVo:Lcom/google/android/gms/cast/internal/zzl;

.field private static final zzVp:I

.field private static final zzVq:Ljava/lang/Object;

.field private static zzVr:Ljava/util/concurrent/atomic/AtomicBoolean;


# instance fields
.field private mHandler:Landroid/os/Handler;

.field private mNotification:Landroid/app/Notification;

.field private zzUM:Ljava/lang/String;

.field private zzVA:Landroid/view/Display;

.field private zzVB:Landroid/content/Context;

.field private zzVC:Landroid/content/ServiceConnection;

.field private zzVD:Landroid/support/v7/media/MediaRouter;

.field private final zzVE:Landroid/support/v7/media/MediaRouter$Callback;

.field private final zzVG:Landroid/os/IBinder;

.field private zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

.field private zzVt:Lcom/google/android/gms/cast/CastRemoteDisplay$CastRemoteDisplaySessionCallbacks;

.field private zzVu:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;

.field private zzVv:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zzb;

.field private zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

.field private zzVx:Ljava/lang/Boolean;

.field private zzVy:Landroid/app/PendingIntent;

.field private zzVz:Lcom/google/android/gms/cast/CastDevice;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    new-instance v0, Lcom/google/android/gms/cast/internal/zzl;

    const-string v1, "CastRemoteDisplayLocalService"

    invoke-direct {v0, v1}, Lcom/google/android/gms/cast/internal/zzl;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    sget v0, Lcom/google/android/gms/R$id;->cast_notification_id:I

    sput v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVp:I

    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    sput-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVq:Ljava/lang/Object;

    new-instance v0, Ljava/util/concurrent/atomic/AtomicBoolean;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Ljava/util/concurrent/atomic/AtomicBoolean;-><init>(Z)V

    sput-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVr:Ljava/util/concurrent/atomic/AtomicBoolean;

    return-void
.end method

.method public constructor <init>()V
    .locals 2

    invoke-direct {p0}, Landroid/app/Service;-><init>()V

    new-instance v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$1;

    invoke-direct {v0, p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$1;-><init>(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)V

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVE:Landroid/support/v7/media/MediaRouter$Callback;

    new-instance v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zza;

    const/4 v1, 0x0

    invoke-direct {v0, p0, v1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zza;-><init>(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$1;)V

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVG:Landroid/os/IBinder;

    return-void
.end method

.method public static getInstance()Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;
    .locals 2

    sget-object v1, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVq:Ljava/lang/Object;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVF:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;

    monitor-exit v1

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method protected static setDebugEnabled()V
    .locals 2

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Lcom/google/android/gms/cast/internal/zzl;->zzX(Z)V

    return-void
.end method

.method public static startService(Landroid/content/Context;Ljava/lang/Class;Ljava/lang/String;Lcom/google/android/gms/cast/CastDevice;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;)V
    .locals 7
    .param p0, "activityContext"    # Landroid/content/Context;
    .param p2, "applicationId"    # Ljava/lang/String;
    .param p3, "device"    # Lcom/google/android/gms/cast/CastDevice;
    .param p4, "notificationSettings"    # Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;
    .param p5, "callbacks"    # Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/lang/Class",
            "<+",
            "Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;",
            ">;",
            "Ljava/lang/String;",
            "Lcom/google/android/gms/cast/CastDevice;",
            "Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;",
            "Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;",
            ")V"
        }
    .end annotation

    .prologue
    .local p1, "serviceClass":Ljava/lang/Class;, "Ljava/lang/Class<+Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;>;"
    const/4 v5, 0x1

    const/4 v4, 0x0

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const-string v1, "Starting Service"

    new-array v2, v4, [Ljava/lang/Object;

    invoke-virtual {v0, v1, v2}, Lcom/google/android/gms/cast/internal/zzl;->zzb(Ljava/lang/String;[Ljava/lang/Object;)V

    sget-object v1, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVq:Ljava/lang/Object;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVF:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;

    if-eqz v0, :cond_0

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const-string v2, "An existing service had not been stopped before starting one"

    const/4 v3, 0x0

    new-array v3, v3, [Ljava/lang/Object;

    invoke-virtual {v0, v2, v3}, Lcom/google/android/gms/cast/internal/zzl;->zzf(Ljava/lang/String;[Ljava/lang/Object;)V

    const/4 v0, 0x1

    invoke-static {v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzR(Z)V

    :cond_0
    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    invoke-static {p0, p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzb(Landroid/content/Context;Ljava/lang/Class;)V

    const-string v0, "activityContext is required."

    invoke-static {p0, v0}, Lcom/google/android/gms/common/internal/zzx;->zzb(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v0, "serviceClass is required."

    invoke-static {p1, v0}, Lcom/google/android/gms/common/internal/zzx;->zzb(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v0, "applicationId is required."

    invoke-static {p2, v0}, Lcom/google/android/gms/common/internal/zzx;->zzb(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v0, "device is required."

    invoke-static {p3, v0}, Lcom/google/android/gms/common/internal/zzx;->zzb(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v0, "notificationSettings is required."

    invoke-static {p4, v0}, Lcom/google/android/gms/common/internal/zzx;->zzb(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v0, "callbacks is required."

    invoke-static {p5, v0}, Lcom/google/android/gms/common/internal/zzx;->zzb(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-static {p4}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/Notification;

    move-result-object v0

    if-nez v0, :cond_1

    invoke-static {p4}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzd(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/PendingIntent;

    move-result-object v0

    if-nez v0, :cond_1

    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "notificationSettings: Either the notification or the notificationPendingIntent must be provided"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    :catchall_0
    move-exception v0

    :try_start_1
    monitor-exit v1
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0

    :cond_1
    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVr:Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-virtual {v0, v5}, Ljava/util/concurrent/atomic/AtomicBoolean;->getAndSet(Z)Z

    move-result v0

    if-eqz v0, :cond_2

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const-string v1, "Service is already being started, startService has been called twice"

    new-array v2, v4, [Ljava/lang/Object;

    invoke-virtual {v0, v1, v2}, Lcom/google/android/gms/cast/internal/zzl;->zzc(Ljava/lang/String;[Ljava/lang/Object;)V

    :goto_0
    return-void

    :cond_2
    new-instance v6, Landroid/content/Intent;

    invoke-direct {v6, p0, p1}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    invoke-virtual {p0, v6}, Landroid/content/Context;->startService(Landroid/content/Intent;)Landroid/content/ComponentName;

    new-instance v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$2;

    move-object v1, p2

    move-object v2, p3

    move-object v3, p4

    move-object v4, p0

    move-object v5, p5

    invoke-direct/range {v0 .. v5}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$2;-><init>(Ljava/lang/String;Lcom/google/android/gms/cast/CastDevice;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;Landroid/content/Context;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;)V

    const/16 v1, 0x40

    invoke-virtual {p0, v6, v0, v1}, Landroid/content/Context;->bindService(Landroid/content/Intent;Landroid/content/ServiceConnection;I)Z

    goto :goto_0
.end method

.method public static stopService()V
    .locals 1

    const/4 v0, 0x0

    invoke-static {v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzR(Z)V

    return-void
.end method

.method private zzQ(Z)V
    .locals 3

    const/4 v2, 0x0

    const-string v0, "Stopping Service"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    if-nez p1, :cond_0

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVD:Landroid/support/v7/media/MediaRouter;

    if-eqz v0, :cond_0

    const-string v0, "Setting default route"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVD:Landroid/support/v7/media/MediaRouter;

    iget-object v1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVD:Landroid/support/v7/media/MediaRouter;

    invoke-virtual {v1}, Landroid/support/v7/media/MediaRouter;->getDefaultRoute()Landroid/support/v7/media/MediaRouter$RouteInfo;

    move-result-object v1

    invoke-virtual {v0, v1}, Landroid/support/v7/media/MediaRouter;->selectRoute(Landroid/support/v7/media/MediaRouter$RouteInfo;)V

    :cond_0
    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVv:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zzb;

    if-eqz v0, :cond_1

    const-string v0, "Unregistering notification receiver"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVv:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zzb;

    invoke-virtual {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->unregisterReceiver(Landroid/content/BroadcastReceiver;)V

    :cond_1
    invoke-direct {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzmp()V

    invoke-direct {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzmq()V

    invoke-direct {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzml()V

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    if-eqz v0, :cond_2

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    invoke-virtual {v0}, Lcom/google/android/gms/common/api/GoogleApiClient;->disconnect()V

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    :cond_2
    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVB:Landroid/content/Context;

    if-eqz v0, :cond_3

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVC:Landroid/content/ServiceConnection;

    if-eqz v0, :cond_3

    :try_start_0
    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVB:Landroid/content/Context;

    iget-object v1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVC:Landroid/content/ServiceConnection;

    invoke-virtual {v0, v1}, Landroid/content/Context;->unbindService(Landroid/content/ServiceConnection;)V
    :try_end_0
    .catch Ljava/lang/IllegalArgumentException; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVC:Landroid/content/ServiceConnection;

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVB:Landroid/content/Context;

    :cond_3
    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzUM:Ljava/lang/String;

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVA:Landroid/view/Display;

    return-void

    :catch_0
    move-exception v0

    const-string v0, "No need to unbind service, already unbound"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    goto :goto_0
.end method

.method private static zzR(Z)V
    .locals 4

    const/4 v3, 0x0

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const-string v1, "Stopping Service"

    new-array v2, v3, [Ljava/lang/Object;

    invoke-virtual {v0, v1, v2}, Lcom/google/android/gms/cast/internal/zzl;->zzb(Ljava/lang/String;[Ljava/lang/Object;)V

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVr:Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-virtual {v0, v3}, Ljava/util/concurrent/atomic/AtomicBoolean;->set(Z)V

    sget-object v1, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVq:Ljava/lang/Object;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVF:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;

    if-nez v0, :cond_0

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const-string v2, "Service is already being stopped"

    const/4 v3, 0x0

    new-array v3, v3, [Ljava/lang/Object;

    invoke-virtual {v0, v2, v3}, Lcom/google/android/gms/cast/internal/zzl;->zzc(Ljava/lang/String;[Ljava/lang/Object;)V

    monitor-exit v1

    :goto_0
    return-void

    :cond_0
    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVF:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;

    const/4 v2, 0x0

    sput-object v2, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVF:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    invoke-direct {v0, p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzQ(Z)V

    goto :goto_0

    :catchall_0
    move-exception v0

    :try_start_1
    monitor-exit v1
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method

.method private zzS(Z)Landroid/app/Notification;
    .locals 7

    const/4 v6, 0x1

    const-string v0, "createDefaultNotification"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->getApplicationInfo()Landroid/content/pm/ApplicationInfo;

    move-result-object v0

    iget v4, v0, Landroid/content/pm/ApplicationInfo;->labelRes:I

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    invoke-static {v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzb(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Ljava/lang/String;

    move-result-object v2

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    invoke-static {v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzc(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Ljava/lang/String;

    move-result-object v3

    if-eqz p1, :cond_1

    sget v1, Lcom/google/android/gms/R$string;->cast_notification_connected_message:I

    sget v0, Lcom/google/android/gms/R$drawable;->cast_ic_notification_on:I

    :goto_0
    invoke-static {v2}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_0

    invoke-virtual {p0, v4}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->getString(I)Ljava/lang/String;

    move-result-object v2

    :cond_0
    invoke-static {v3}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_2

    new-array v3, v6, [Ljava/lang/Object;

    const/4 v4, 0x0

    iget-object v5, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVz:Lcom/google/android/gms/cast/CastDevice;

    invoke-virtual {v5}, Lcom/google/android/gms/cast/CastDevice;->getFriendlyName()Ljava/lang/String;

    move-result-object v5

    aput-object v5, v3, v4

    invoke-virtual {p0, v1, v3}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->getString(I[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    :goto_1
    new-instance v3, Landroid/support/v4/app/NotificationCompat$Builder;

    invoke-direct {v3, p0}, Landroid/support/v4/app/NotificationCompat$Builder;-><init>(Landroid/content/Context;)V

    invoke-virtual {v3, v2}, Landroid/support/v4/app/NotificationCompat$Builder;->setContentTitle(Ljava/lang/CharSequence;)Landroid/support/v4/app/NotificationCompat$Builder;

    move-result-object v2

    invoke-virtual {v2, v1}, Landroid/support/v4/app/NotificationCompat$Builder;->setContentText(Ljava/lang/CharSequence;)Landroid/support/v4/app/NotificationCompat$Builder;

    move-result-object v1

    iget-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    invoke-static {v2}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzd(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/PendingIntent;

    move-result-object v2

    invoke-virtual {v1, v2}, Landroid/support/v4/app/NotificationCompat$Builder;->setContentIntent(Landroid/app/PendingIntent;)Landroid/support/v4/app/NotificationCompat$Builder;

    move-result-object v1

    invoke-virtual {v1, v0}, Landroid/support/v4/app/NotificationCompat$Builder;->setSmallIcon(I)Landroid/support/v4/app/NotificationCompat$Builder;

    move-result-object v0

    invoke-virtual {v0, v6}, Landroid/support/v4/app/NotificationCompat$Builder;->setOngoing(Z)Landroid/support/v4/app/NotificationCompat$Builder;

    move-result-object v0

    const v1, 0x1080038

    sget v2, Lcom/google/android/gms/R$string;->cast_notification_disconnect:I

    invoke-virtual {p0, v2}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->getString(I)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzmr()Landroid/app/PendingIntent;

    move-result-object v3

    invoke-virtual {v0, v1, v2, v3}, Landroid/support/v4/app/NotificationCompat$Builder;->addAction(ILjava/lang/CharSequence;Landroid/app/PendingIntent;)Landroid/support/v4/app/NotificationCompat$Builder;

    move-result-object v0

    invoke-virtual {v0}, Landroid/support/v4/app/NotificationCompat$Builder;->build()Landroid/app/Notification;

    move-result-object v0

    return-object v0

    :cond_1
    sget v1, Lcom/google/android/gms/R$string;->cast_notification_connecting_message:I

    sget v0, Lcom/google/android/gms/R$drawable;->cast_ic_notification_connecting:I

    goto :goto_0

    :cond_2
    move-object v1, v3

    goto :goto_1
.end method

.method static synthetic zzT(Z)V
    .locals 0

    invoke-static {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzR(Z)V

    return-void
.end method

.method static synthetic zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;Landroid/content/Context;)Landroid/content/Context;
    .locals 0

    iput-object p1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVB:Landroid/content/Context;

    return-object p1
.end method

.method static synthetic zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;Landroid/content/ServiceConnection;)Landroid/content/ServiceConnection;
    .locals 0

    iput-object p1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVC:Landroid/content/ServiceConnection;

    return-object p1
.end method

.method static synthetic zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)Lcom/google/android/gms/cast/CastDevice;
    .locals 1

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVz:Lcom/google/android/gms/cast/CastDevice;

    return-object v0
.end method

.method private zza(Lcom/google/android/gms/cast/CastDevice;)Lcom/google/android/gms/common/api/GoogleApiClient;
    .locals 4

    new-instance v0, Lcom/google/android/gms/cast/CastRemoteDisplay$CastRemoteDisplayOptions$Builder;

    iget-object v1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVt:Lcom/google/android/gms/cast/CastRemoteDisplay$CastRemoteDisplaySessionCallbacks;

    invoke-direct {v0, p1, v1}, Lcom/google/android/gms/cast/CastRemoteDisplay$CastRemoteDisplayOptions$Builder;-><init>(Lcom/google/android/gms/cast/CastDevice;Lcom/google/android/gms/cast/CastRemoteDisplay$CastRemoteDisplaySessionCallbacks;)V

    new-instance v1, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$6;

    invoke-direct {v1, p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$6;-><init>(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)V

    new-instance v2, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$7;

    invoke-direct {v2, p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$7;-><init>(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)V

    new-instance v3, Lcom/google/android/gms/common/api/GoogleApiClient$Builder;

    invoke-direct {v3, p0, v1, v2}, Lcom/google/android/gms/common/api/GoogleApiClient$Builder;-><init>(Landroid/content/Context;Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V

    sget-object v1, Lcom/google/android/gms/cast/CastRemoteDisplay;->API:Lcom/google/android/gms/common/api/Api;

    invoke-virtual {v0}, Lcom/google/android/gms/cast/CastRemoteDisplay$CastRemoteDisplayOptions$Builder;->build()Lcom/google/android/gms/cast/CastRemoteDisplay$CastRemoteDisplayOptions;

    move-result-object v0

    invoke-virtual {v3, v1, v0}, Lcom/google/android/gms/common/api/GoogleApiClient$Builder;->addApi(Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions$HasOptions;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/android/gms/common/api/GoogleApiClient$Builder;->build()Lcom/google/android/gms/common/api/GoogleApiClient;

    move-result-object v0

    return-object v0
.end method

.method private zza(Landroid/view/Display;)V
    .locals 2

    iput-object p1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVA:Landroid/view/Display;

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVx:Ljava/lang/Boolean;

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzS(Z)Landroid/app/Notification;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    sget v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVp:I

    iget-object v1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    invoke-virtual {p0, v0, v1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->startForeground(ILandroid/app/Notification;)V

    :cond_0
    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVu:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVu:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;

    invoke-interface {v0, p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;->onRemoteDisplaySessionStarted(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)V

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVu:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;

    :cond_1
    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVA:Landroid/view/Display;

    invoke-virtual {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->onCreatePresentation(Landroid/view/Display;)V

    return-void
.end method

.method static synthetic zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;Landroid/view/Display;)V
    .locals 0

    invoke-direct {p0, p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zza(Landroid/view/Display;)V

    return-void
.end method

.method static synthetic zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;Ljava/lang/String;)V
    .locals 0

    invoke-direct {p0, p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;Ljava/lang/String;Lcom/google/android/gms/cast/CastDevice;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;Landroid/content/Context;Landroid/content/ServiceConnection;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;)Z
    .locals 1

    invoke-direct/range {p0 .. p6}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zza(Ljava/lang/String;Lcom/google/android/gms/cast/CastDevice;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;Landroid/content/Context;Landroid/content/ServiceConnection;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;)Z

    move-result v0

    return v0
.end method

.method private zza(Ljava/lang/String;Lcom/google/android/gms/cast/CastDevice;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;Landroid/content/Context;Landroid/content/ServiceConnection;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;)Z
    .locals 7

    const/4 v6, 0x0

    const/4 v1, 0x1

    const/4 v0, 0x0

    const-string v2, "startRemoteDisplaySession"

    invoke-direct {p0, v2}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    const-string v2, "Starting the Cast Remote Display must be done on the main thread"

    invoke-static {v2}, Lcom/google/android/gms/common/internal/zzx;->zzci(Ljava/lang/String;)V

    sget-object v2, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVq:Ljava/lang/Object;

    monitor-enter v2

    :try_start_0
    sget-object v3, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVF:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;

    if-eqz v3, :cond_0

    sget-object v1, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const-string v3, "An existing service had not been stopped before starting one"

    const/4 v4, 0x0

    new-array v4, v4, [Ljava/lang/Object;

    invoke-virtual {v1, v3, v4}, Lcom/google/android/gms/cast/internal/zzl;->zzf(Ljava/lang/String;[Ljava/lang/Object;)V

    monitor-exit v2

    :goto_0
    return v0

    :cond_0
    sput-object p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVF:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;

    monitor-exit v2
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    iput-object p6, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVu:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;

    iput-object p1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzUM:Ljava/lang/String;

    iput-object p2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVz:Lcom/google/android/gms/cast/CastDevice;

    iput-object p4, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVB:Landroid/content/Context;

    iput-object p5, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVC:Landroid/content/ServiceConnection;

    invoke-virtual {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->getApplicationContext()Landroid/content/Context;

    move-result-object v2

    invoke-static {v2}, Landroid/support/v7/media/MediaRouter;->getInstance(Landroid/content/Context;)Landroid/support/v7/media/MediaRouter;

    move-result-object v2

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVD:Landroid/support/v7/media/MediaRouter;

    new-instance v2, Landroid/support/v7/media/MediaRouteSelector$Builder;

    invoke-direct {v2}, Landroid/support/v7/media/MediaRouteSelector$Builder;-><init>()V

    iget-object v3, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzUM:Ljava/lang/String;

    invoke-static {v3}, Lcom/google/android/gms/cast/CastMediaControlIntent;->categoryForCast(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Landroid/support/v7/media/MediaRouteSelector$Builder;->addControlCategory(Ljava/lang/String;)Landroid/support/v7/media/MediaRouteSelector$Builder;

    move-result-object v2

    invoke-virtual {v2}, Landroid/support/v7/media/MediaRouteSelector$Builder;->build()Landroid/support/v7/media/MediaRouteSelector;

    move-result-object v2

    const-string v3, "addMediaRouterCallback"

    invoke-direct {p0, v3}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    iget-object v3, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVD:Landroid/support/v7/media/MediaRouter;

    iget-object v4, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVE:Landroid/support/v7/media/MediaRouter$Callback;

    const/4 v5, 0x4

    invoke-virtual {v3, v2, v4, v5}, Landroid/support/v7/media/MediaRouter;->addCallback(Landroid/support/v7/media/MediaRouteSelector;Landroid/support/v7/media/MediaRouter$Callback;I)V

    new-instance v2, Landroid/os/Handler;

    invoke-virtual {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->getMainLooper()Landroid/os/Looper;

    move-result-object v3

    invoke-direct {v2, v3}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mHandler:Landroid/os/Handler;

    invoke-static {p3}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/Notification;

    move-result-object v2

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    new-instance v2, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zzb;

    invoke-direct {v2, v6}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zzb;-><init>(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$1;)V

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVv:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zzb;

    iget-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVv:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$zzb;

    new-instance v3, Landroid/content/IntentFilter;

    const-string v4, "com.google.android.gms.cast.remote_display.ACTION_NOTIFICATION_DISCONNECT"

    invoke-direct {v3, v4}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    invoke-virtual {p0, v2, v3}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    new-instance v2, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    invoke-direct {v2, p3, v6}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;-><init>(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$1;)V

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    iget-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    invoke-static {v2}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/Notification;

    move-result-object v2

    if-nez v2, :cond_1

    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v2

    iput-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVx:Ljava/lang/Boolean;

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzS(Z)Landroid/app/Notification;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    :goto_1
    sget v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVp:I

    iget-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    invoke-virtual {p0, v0, v2}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->startForeground(ILandroid/app/Notification;)V

    invoke-direct {p0, p2}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zza(Lcom/google/android/gms/cast/CastDevice;)Lcom/google/android/gms/common/api/GoogleApiClient;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    invoke-virtual {v0}, Lcom/google/android/gms/common/api/GoogleApiClient;->connect()V

    move v0, v1

    goto/16 :goto_0

    :catchall_0
    move-exception v0

    :try_start_1
    monitor-exit v2
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0

    :cond_1
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVx:Ljava/lang/Boolean;

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    invoke-static {v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/Notification;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    goto :goto_1
.end method

.method static synthetic zzb(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)Landroid/os/Handler;
    .locals 1

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mHandler:Landroid/os/Handler;

    return-object v0
.end method

.method static synthetic zzb(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;Landroid/view/Display;)Landroid/view/Display;
    .locals 0

    iput-object p1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVA:Landroid/view/Display;

    return-object p1
.end method

.method private static zzb(Landroid/content/Context;Ljava/lang/Class;)V
    .locals 3

    :try_start_0
    new-instance v0, Landroid/content/ComponentName;

    invoke-direct {v0, p0, p1}, Landroid/content/ComponentName;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v1

    const/16 v2, 0x80

    invoke-virtual {v1, v0, v2}, Landroid/content/pm/PackageManager;->getServiceInfo(Landroid/content/ComponentName;I)Landroid/content/pm/ServiceInfo;

    move-result-object v0

    if-eqz v0, :cond_0

    iget-boolean v0, v0, Landroid/content/pm/ServiceInfo;->exported:Z

    if-eqz v0, :cond_0

    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "The service must not be exported, verify the manifest configuration"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
    :try_end_0
    .catch Landroid/content/pm/PackageManager$NameNotFoundException; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    move-exception v0

    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "Service not found, did you forget to configure it in the manifest?"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_0
    return-void
.end method

.method static synthetic zzb(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;Ljava/lang/String;)V
    .locals 0

    invoke-direct {p0, p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbe(Ljava/lang/String;)V

    return-void
.end method

.method private zzbb(Ljava/lang/String;)V
    .locals 4

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const-string v1, "[Instance: %s] %s"

    const/4 v2, 0x2

    new-array v2, v2, [Ljava/lang/Object;

    const/4 v3, 0x0

    aput-object p0, v2, v3

    const/4 v3, 0x1

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/google/android/gms/cast/internal/zzl;->zzb(Ljava/lang/String;[Ljava/lang/Object;)V

    return-void
.end method

.method private zzbe(Ljava/lang/String;)V
    .locals 4

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const-string v1, "[Instance: %s] %s"

    const/4 v2, 0x2

    new-array v2, v2, [Ljava/lang/Object;

    const/4 v3, 0x0

    aput-object p0, v2, v3

    const/4 v3, 0x1

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/google/android/gms/cast/internal/zzl;->zzc(Ljava/lang/String;[Ljava/lang/Object;)V

    return-void
.end method

.method static synthetic zzc(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)V
    .locals 0

    invoke-direct {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzmo()V

    return-void
.end method

.method static synthetic zzd(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)Landroid/content/Context;
    .locals 1

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVB:Landroid/content/Context;

    return-object v0
.end method

.method static synthetic zze(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)Landroid/content/ServiceConnection;
    .locals 1

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVC:Landroid/content/ServiceConnection;

    return-object v0
.end method

.method static synthetic zzf(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)V
    .locals 0

    invoke-direct {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzmm()V

    return-void
.end method

.method private zzml()V
    .locals 2

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVD:Landroid/support/v7/media/MediaRouter;

    if-eqz v0, :cond_0

    const-string v0, "CastRemoteDisplayLocalService calls must be done on the main thread"

    invoke-static {v0}, Lcom/google/android/gms/common/internal/zzx;->zzci(Ljava/lang/String;)V

    const-string v0, "removeMediaRouterCallback"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVD:Landroid/support/v7/media/MediaRouter;

    iget-object v1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVE:Landroid/support/v7/media/MediaRouter$Callback;

    invoke-virtual {v0, v1}, Landroid/support/v7/media/MediaRouter;->removeCallback(Landroid/support/v7/media/MediaRouter$Callback;)V

    :cond_0
    return-void
.end method

.method private zzmm()V
    .locals 3

    const-string v0, "startRemoteDisplay"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    invoke-virtual {v0}, Lcom/google/android/gms/common/api/GoogleApiClient;->isConnected()Z

    move-result v0

    if-nez v0, :cond_1

    :cond_0
    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const-string v1, "Unable to start the remote display as the API client is not ready"

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/Object;

    invoke-virtual {v0, v1, v2}, Lcom/google/android/gms/cast/internal/zzl;->zzc(Ljava/lang/String;[Ljava/lang/Object;)V

    :goto_0
    return-void

    :cond_1
    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplay;->CastRemoteDisplayApi:Lcom/google/android/gms/cast/CastRemoteDisplayApi;

    iget-object v1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    iget-object v2, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzUM:Ljava/lang/String;

    invoke-interface {v0, v1, v2}, Lcom/google/android/gms/cast/CastRemoteDisplayApi;->startRemoteDisplay(Lcom/google/android/gms/common/api/GoogleApiClient;Ljava/lang/String;)Lcom/google/android/gms/common/api/PendingResult;

    move-result-object v0

    new-instance v1, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$4;

    invoke-direct {v1, p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$4;-><init>(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)V

    invoke-virtual {v0, v1}, Lcom/google/android/gms/common/api/PendingResult;->setResultCallback(Lcom/google/android/gms/common/api/ResultCallback;)V

    goto :goto_0
.end method

.method private zzmn()V
    .locals 3

    const-string v0, "stopRemoteDisplay"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    invoke-virtual {v0}, Lcom/google/android/gms/common/api/GoogleApiClient;->isConnected()Z

    move-result v0

    if-nez v0, :cond_1

    :cond_0
    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    const-string v1, "Unable to stop the remote display as the API client is not ready"

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/Object;

    invoke-virtual {v0, v1, v2}, Lcom/google/android/gms/cast/internal/zzl;->zzc(Ljava/lang/String;[Ljava/lang/Object;)V

    :goto_0
    return-void

    :cond_1
    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplay;->CastRemoteDisplayApi:Lcom/google/android/gms/cast/CastRemoteDisplayApi;

    iget-object v1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVs:Lcom/google/android/gms/common/api/GoogleApiClient;

    invoke-interface {v0, v1}, Lcom/google/android/gms/cast/CastRemoteDisplayApi;->stopRemoteDisplay(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/common/api/PendingResult;

    move-result-object v0

    new-instance v1, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$5;

    invoke-direct {v1, p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$5;-><init>(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)V

    invoke-virtual {v0, v1}, Lcom/google/android/gms/common/api/PendingResult;->setResultCallback(Lcom/google/android/gms/common/api/ResultCallback;)V

    goto :goto_0
.end method

.method private zzmo()V
    .locals 3

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVu:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVu:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;

    new-instance v1, Lcom/google/android/gms/common/api/Status;

    const/16 v2, 0x898

    invoke-direct {v1, v2}, Lcom/google/android/gms/common/api/Status;-><init>(I)V

    invoke-interface {v0, v1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;->onRemoteDisplaySessionError(Lcom/google/android/gms/common/api/Status;)V

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVu:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$Callbacks;

    :cond_0
    invoke-static {}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->stopService()V

    return-void
.end method

.method private zzmp()V
    .locals 1

    const-string v0, "stopRemoteDisplaySession"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzmn()V

    invoke-virtual {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->onDismissPresentation()V

    return-void
.end method

.method private zzmq()V
    .locals 1

    const-string v0, "Stopping the remote display Service"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    const/4 v0, 0x1

    invoke-virtual {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->stopForeground(Z)V

    invoke-virtual {p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->stopSelf()V

    return-void
.end method

.method private zzmr()Landroid/app/PendingIntent;
    .locals 3

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVy:Landroid/app/PendingIntent;

    if-nez v0, :cond_0

    new-instance v0, Landroid/content/Intent;

    const-string v1, "com.google.android.gms.cast.remote_display.ACTION_NOTIFICATION_DISCONNECT"

    invoke-direct {v0, v1}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    const/4 v1, 0x0

    const/high16 v2, 0x10000000

    invoke-static {p0, v1, v0, v2}, Landroid/app/PendingIntent;->getBroadcast(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVy:Landroid/app/PendingIntent;

    :cond_0
    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVy:Landroid/app/PendingIntent;

    return-object v0
.end method

.method static synthetic zzms()Lcom/google/android/gms/cast/internal/zzl;
    .locals 1

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVo:Lcom/google/android/gms/cast/internal/zzl;

    return-object v0
.end method

.method static synthetic zzmt()Ljava/util/concurrent/atomic/AtomicBoolean;
    .locals 1

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVr:Ljava/util/concurrent/atomic/AtomicBoolean;

    return-object v0
.end method

.method static synthetic zzmu()Ljava/lang/Object;
    .locals 1

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVq:Ljava/lang/Object;

    return-object v0
.end method

.method static synthetic zzmv()Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;
    .locals 1

    sget-object v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVF:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;

    return-object v0
.end method


# virtual methods
.method protected getDisplay()Landroid/view/Display;
    .locals 1

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVA:Landroid/view/Display;

    return-object v0
.end method

.method public onBind(Landroid/content/Intent;)Landroid/os/IBinder;
    .locals 1
    .param p1, "intent"    # Landroid/content/Intent;

    .prologue
    const-string v0, "onBind"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVG:Landroid/os/IBinder;

    return-object v0
.end method

.method public onCreate()V
    .locals 1

    invoke-super {p0}, Landroid/app/Service;->onCreate()V

    new-instance v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$3;

    invoke-direct {v0, p0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$3;-><init>(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;)V

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVt:Lcom/google/android/gms/cast/CastRemoteDisplay$CastRemoteDisplaySessionCallbacks;

    return-void
.end method

.method public abstract onCreatePresentation(Landroid/view/Display;)V
.end method

.method public abstract onDismissPresentation()V
.end method

.method public onStartCommand(Landroid/content/Intent;II)I
    .locals 1
    .param p1, "intent"    # Landroid/content/Intent;
    .param p2, "flags"    # I
    .param p3, "startId"    # I

    .prologue
    const-string v0, "onStartCommand"

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzbb(Ljava/lang/String;)V

    const/4 v0, 0x2

    return v0
.end method

.method public updateNotificationSettings(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)V
    .locals 2
    .param p1, "notificationSettings"    # Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    .prologue
    const-string v0, "notificationSettings is required."

    invoke-static {p1, v0}, Lcom/google/android/gms/common/internal/zzx;->zzb(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    if-nez v0, :cond_0

    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "No current notification settings to update"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_0
    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVx:Ljava/lang/Boolean;

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    if-eqz v0, :cond_5

    invoke-static {p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/Notification;

    move-result-object v0

    if-eqz v0, :cond_1

    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "Current mode is default notification, notification attribute must not be provided"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_1
    invoke-static {p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzd(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/PendingIntent;

    move-result-object v0

    if-eqz v0, :cond_2

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    invoke-static {p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzd(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/PendingIntent;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;Landroid/app/PendingIntent;)Landroid/app/PendingIntent;

    :cond_2
    invoke-static {p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzb(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_3

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    invoke-static {p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzb(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;Ljava/lang/String;)Ljava/lang/String;

    :cond_3
    invoke-static {p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzc(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_4

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    invoke-static {p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzc(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zzb(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;Ljava/lang/String;)Ljava/lang/String;

    :cond_4
    const/4 v0, 0x1

    invoke-direct {p0, v0}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzS(Z)Landroid/app/Notification;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    :goto_0
    sget v0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVp:I

    iget-object v1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    invoke-virtual {p0, v0, v1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->startForeground(ILandroid/app/Notification;)V

    return-void

    :cond_5
    invoke-static {p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/Notification;

    move-result-object v0

    const-string v1, "notification is required."

    invoke-static {v0, v1}, Lcom/google/android/gms/common/internal/zzx;->zzb(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-static {p1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;)Landroid/app/Notification;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    iget-object v0, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->zzVw:Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;

    iget-object v1, p0, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService;->mNotification:Landroid/app/Notification;

    invoke-static {v0, v1}, Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;->zza(Lcom/google/android/gms/cast/CastRemoteDisplayLocalService$NotificationSettings;Landroid/app/Notification;)Landroid/app/Notification;

    goto :goto_0
.end method
