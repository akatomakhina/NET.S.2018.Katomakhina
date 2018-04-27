using System;
using NLog;

namespace LabExam.Logger
{
    class NLogger : ILogger
    {
        #region private fields

        private readonly NLog.Logger logger;

        #endregion // !private fields.

        #region constructors

        public NLogger(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException($"{nameof(className)} IsNullOrWhiteSpace", nameof(className));
            }

            logger = LogManager.GetLogger(className);
        }

        #endregion // !constructors.

        #region interface implementation

        /// <inheritdoc />
        public void Trace(string message) =>
            logger.Trace(message);

        /// <inheritdoc />
        public void Trace(string message, Exception exception) =>
            logger.Trace(exception, message);

        /// <inheritdoc />
        public void Debug(string message) =>
            logger.Debug(message);

        /// <inheritdoc />
        public void Debug(string message, Exception exception) =>
            logger.Debug(exception, message);

        /// <inheritdoc />
        public void Info(string message) =>
            logger.Info(message);

        /// <inheritdoc />
        public void Info(string message, Exception exception) =>
            logger.Info(exception, message);

        /// <inheritdoc />
        public void Warn(string message) =>
            logger.Warn(message);

        /// <inheritdoc />
        public void Warn(string message, Exception exception) =>
            logger.Warn(exception, message);

        /// <inheritdoc />
        public void Error(string message) =>
            logger.Error(message);

        /// <inheritdoc />
        public void Error(string message, Exception exception) =>
            logger.Error(exception, message);

        /// <inheritdoc />
        public void Fatal(string message) =>
            logger.Fatal(message);

        /// <inheritdoc />
        public void Fatal(string message, Exception exception) =>
            logger.Fatal(exception, message);

        #endregion // !interface implementation.
    }
}
