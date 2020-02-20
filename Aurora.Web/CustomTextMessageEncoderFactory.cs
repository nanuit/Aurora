using System.ServiceModel.Channels;

namespace Aurora.Web
{
    public class CustomTextMessageEncoderFactory : MessageEncoderFactory
    {
        internal CustomTextMessageEncoderFactory(string mediaType, string charSet,
            MessageVersion version)
        {
            this.MessageVersion = version;
            this.MediaType = mediaType;
            this.CharSet = charSet;
            this.Encoder = new CustomTextMessageEncoder(this);
        }

        public override MessageEncoder Encoder { get; }

        public override MessageVersion MessageVersion { get; }

        internal string MediaType { get; }

        internal string CharSet { get; }
    }

}
