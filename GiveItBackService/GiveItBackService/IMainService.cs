using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GiveItBackService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMainService" in both code and config file together.
    [ServiceContract]
    public interface IMainService
    {
        [OperationContract]
        void DoWork();
        
        [OperationContract]
        List<BatPost> GetAllData();

        [OperationContract]
        string InsertMember(BatPost post);

    }

    /// <summary>
    /// Testowa struktura do przetestowania przesyłu danych
    /// </summary>
    [DataContract]
    public class BatPost
    {
        int _postID;
        string _title;
        string _post;

        [DataMember]
        public int PostID
        {
            get
            {
                return _postID;
            }
            set
            {
                _postID = value;
            }
        }
        [DataMember]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        [DataMember]
        public string Post
        {
            get
            {
                return _post;
            }
            set
            {
                _post = value;
            }
        }
    }
}
