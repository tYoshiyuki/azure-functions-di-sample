using System;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsDiSample.Applications
{
    public abstract class BaseApplication : IApplication
    {
        protected readonly ILogger<IApplication> Logger;

        protected BaseApplication(ILogger<IApplication> logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// 処理実行
        /// </summary>
        public void Run()
        {
            try
            {
                Before();

                Main();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "処理失敗");
                Logger.LogError(ex.Message);
                Logger.LogError(ex.StackTrace);
            }
            finally
            {
                After();
            }
        }

        /// <summary>
        /// 事前処理
        /// </summary>
        protected virtual void Before()
        {
            Logger.LogInformation("処理開始");
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        protected abstract void Main();

        /// <summary>
        /// 事後処理
        /// </summary>
        protected virtual void After()
        {
            Logger.LogInformation("処理完了");
        }
    }
}
