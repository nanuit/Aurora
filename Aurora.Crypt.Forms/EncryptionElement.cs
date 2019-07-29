namespace Aurora.Crypt.Forms
{
    public class EncryptionElement
    {
        public string ApplicationName { get; set; }
        public string ApplicationId { get; set; }

        public EncryptionElement(string applicationName, string applicationId)
        {
            ApplicationName = applicationName;
            ApplicationId = applicationId;
        }
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return ApplicationName;
        }
    }
}
