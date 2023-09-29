﻿using Amazon.Internal;
using Amazon.Runtime;
using Amazon.S3;
using Microsoft.Extensions.Configuration;

namespace Workneering.Packages.Storage.AWS3.Extensions;
public static class AWS3ConfigurationExtension
{
    public static BasicAWSCredentials GetBasicAWSCredentials(IConfiguration configuration)
    {
        var config = configuration.GetAWSConfigurationOptions();
        var credentials = new BasicAWSCredentials(config.AWSAccessKey, config.AWSSecretKey);
        return credentials;
    }
    public static AmazonS3Config GetRgionAWS()
    {
        var config = new AmazonS3Config()
        {
            RegionEndpoint = Amazon.RegionEndpoint.EUNorth1
        };
        return config;
    }


}
