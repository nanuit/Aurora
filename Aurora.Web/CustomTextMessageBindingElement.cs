using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;


namespace Aurora.Web
{
    public class CustomTextMessageBindingElement : MessageEncodingBindingElement, IWsdlExportExtension 
    { 
        private MessageVersion msgVersion; 
        private string mediaType; 
        private string encoding;

        CustomTextMessageBindingElement(CustomTextMessageBindingElement binding) 
            : this(binding.Encoding, binding.MediaType, binding.MessageVersion) 
        { 
            this.ReaderQuotas = new XmlDictionaryReaderQuotas(); 
            binding.ReaderQuotas.CopyTo(this.ReaderQuotas); 
        } 
 
        public CustomTextMessageBindingElement(string encoding, string mediaType, 
            MessageVersion msgVersion) 
        {
            this.msgVersion = msgVersion ?? throw new ArgumentNullException("msgVersion"); 
            this.mediaType = mediaType ?? throw new ArgumentNullException("mediaType"); 
            this.encoding = encoding ?? throw new ArgumentNullException("encoding"); 
            this.ReaderQuotas = new XmlDictionaryReaderQuotas(); 
        } 
 
        public CustomTextMessageBindingElement(string encoding, string mediaType) 
            : this(encoding, mediaType, MessageVersion.Soap11WSAddressing10) 
        { 
        } 
 
        public CustomTextMessageBindingElement(string encoding) 
            : this(encoding, "text/xml") 
        { 
 
        } 
 
        public CustomTextMessageBindingElement() 
            : this("UTF-8") 
        { 
        } 
 
        public override MessageVersion MessageVersion 
        { 
            get => this.msgVersion;

            set => this.msgVersion = value ?? throw new ArgumentNullException("value");
        } 
 
 
        public string MediaType 
        { 
            get => this.mediaType;

            set => this.mediaType = value ?? throw new ArgumentNullException("value");
        } 
 
        public string Encoding 
        { 
            get => this.encoding;

            set => this.encoding = value ?? throw new ArgumentNullException("value");
        } 
 
        // This encoder does not enforces any quotas for the unsecure messages. The  
        // quotas are enforced for the secure portions of messages when this encoder 
        // is used in a binding that is configured with security.  
        public XmlDictionaryReaderQuotas ReaderQuotas { get; }

        #region IMessageEncodingBindingElement Members 
 
        public override MessageEncoderFactory CreateMessageEncoderFactory() 
        { 
            return new CustomTextMessageEncoderFactory(this.MediaType, 
                this.Encoding, this.MessageVersion); 
        } 
 
        #endregion 
 
 
        public override BindingElement Clone() 
        { 
            return new CustomTextMessageBindingElement(this); 
        } 
 
        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context) 
        { 
            if (context == null) 
                throw new ArgumentNullException("context"); 
 
            context.BindingParameters.Add(this); 
            return context.BuildInnerChannelFactory<TChannel>(); 
        } 
 
        public override bool CanBuildChannelFactory<TChannel>(BindingContext context) 
        { 
            if (context == null) 
                throw new ArgumentNullException("context"); 
 
            return context.CanBuildInnerChannelFactory<TChannel>(); 
        } 
 
        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context) 
        { 
            if (context == null) 
                throw new ArgumentNullException("context"); 
 
            context.BindingParameters.Add(this); 
            return context.BuildInnerChannelListener<TChannel>(); 
        } 
 
        public override bool CanBuildChannelListener<TChannel>(BindingContext context) 
        { 
            if (context == null) 
                throw new ArgumentNullException("context"); 
 
            context.BindingParameters.Add(this); 
            return context.CanBuildInnerChannelListener<TChannel>(); 
        } 
 
        public override T GetProperty<T>(BindingContext context) 
        { 
            if (typeof(T) == typeof(XmlDictionaryReaderQuotas)) 
            { 
                return (T)(object)this.ReaderQuotas; 
            } 
            else 
            { 
                return base.GetProperty<T>(context); 
            } 
        } 
 
        #region IWsdlExportExtension Members 
 
        void IWsdlExportExtension.ExportContract(WsdlExporter exporter, WsdlContractConversionContext context) 
        { 
        } 
 
        void IWsdlExportExtension.ExportEndpoint(WsdlExporter exporter, WsdlEndpointConversionContext context) 
        { 
            // The MessageEncodingBindingElement is responsible for ensuring that the WSDL has the correct 
            // SOAP version. We can delegate to the WCF implementation of TextMessageEncodingBindingElement for this. 
            TextMessageEncodingBindingElement mebe = new TextMessageEncodingBindingElement(); 
            mebe.MessageVersion = this.msgVersion; 
            ((IWsdlExportExtension)mebe).ExportEndpoint(exporter, context); 
        } 
 
        #endregion 
    } 
   
}
