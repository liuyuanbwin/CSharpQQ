using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TongXing.FileCenter;
using System.Net;
using System.Windows.Forms;
namespace Project1
{
    public class FileSendMust : IFileSendMust
    {

        #region IFileSendMust 成员
        /// <summary>
        /// 接收方拒绝接收文件
        /// </summary>
        /// <param name="FileLabel">文件标签</param>
        public void FileRefuse(int FileLabel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 开始传输
        /// </summary>
        /// <param name="FileLabel">文件标签</param>
        public void FileStart(int FileLabel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 发送完成
        /// </summary>
        /// <param name="FileLabel">文件标签</param>
        public void SendSuccess(int FileLabel)
        {
            MessageBox.Show("发送完成");
        }

        #endregion

        #region IFileMustBase 成员

        /// <summary>
        /// 文件已中断；状态已自动改为暂停状态；等待对方上线的时候；进行续传；
        /// </summary>
        /// <param name="FileLabel">文件标签</param>
        /// <param name="Reason">中断原因</param>
        public void FileBreak(int FileLabel, string Reason)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 对方已经取消这个文件的传输；我方已经关掉这个传输
        /// </summary>
        /// <param name="FileLabel">文件标签</param>
        public void FileCancel(int FileLabel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 文件开始续传；这时不会触发开始传输的方法
        /// </summary>
        /// <param name="FileLabel">文件标签</param>
        public void FileContinue(int FileLabel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 文件传输失败
        /// </summary>
        /// <param name="FileLabel">文件标签</param>
        public void FileFailure(int FileLabel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 对方拒绝续传;文件又处于暂停状态；
        /// </summary>
        /// <param name="FileLabel">文件标签</param>
        public void FileNoContinue(int FileLabel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 对方发过来的续传确认信息；你是否同意续传；
        /// </summary>
        /// <param name="FileLabel">文件标签</param>
        /// <returns>同意或不同意</returns>
        public bool FileOrNotContingue(int FileLabel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 对方暂停；我方也已经暂停；等待着对方的再一次请求传输；会在FileOrNotContingue这里触发
        /// </summary>
        /// <param name="FileLabel">文件标签</param>
        public void FileStop(int FileLabel)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
