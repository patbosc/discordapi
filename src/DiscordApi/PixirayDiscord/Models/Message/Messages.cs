﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;
using Newtonsoft.Json;

namespace Pixiray.Discord.Api.Models
{
    /// <summary>
    /// Messages Object as specified
    /// Represents a message sent in a channel within Discord.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// id of the message
        /// Type: Snowflake
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// id of the channel the message was sent in
        /// Type: Snowflake
        /// </summary>
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        //TODO: DoubleCheck https://discordapp.com/developers/docs/resources/channel#overwrite-object

        /// <summary>
        /// the author of this message (not guaranteed to be a valid user, see below)
        /// Type: Object:User
        /// NOTE:
        /// The author object follows the structure of the user object,
        /// but is only a valid user in the case where the message is generated by a user or bot user.
        /// If the message is generated by a webhook, the author object corresponds to the webhook's id, username, and avatar.
        /// You can tell if a message is generated by a webhook by checking for the webhook_id on the message object.
        /// </summary>
        [JsonProperty("author")]
        public User Author { get; set; }

        /// <summary>
        /// contents of the message
        /// Type: String : Markdown
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// when this message was sent
        /// Type: Timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime? TimeStamp { get; set; }

        /// <summary>
        /// when this message was edited (or null if never)
        /// Type: ?timestamp
        /// </summary>
        [JsonProperty("edited_timestamp")]
        public DateTime? Edited { get; set; }

        /// <summary>
        /// whether this was a TTS message
        /// </summary>
        [JsonProperty("tts")]
        public bool Tts { get; set; }

        /// <summary>
        /// whether this message mentions everyone
        /// </summary>
        [JsonProperty("mention_everyone")]
        public bool Mention { get; set; }

        /// <summary>
        /// users specifically mentioned in the message
        /// </summary>
        [JsonProperty("mentions")]
        public List<User> Mentions { get; set; }

        /// <summary>
        /// roles specifically mentioned in this message
        /// </summary>
        [JsonProperty("mention_roles")]
        public List<Role> MentionedRoles { get; set; }

        /// <summary>
        /// any attached files
        /// array of attachment objects
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// any embedded content
        /// array of embed objects
        /// </summary>
        [JsonProperty("embeds")]
        public List<Embed> Embeds { get; set; }

        /// <summary>
        /// reactions to the message
        /// Type: array of reaction objects
        /// </summary>
        [JsonProperty("reactions")]
        public List<Reaction> Reactions { get; set; }

        /// <summary>
        /// used for validating a message was sent
        /// </summary>
        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        /// <summary>
        /// whether this message is pinned
        /// Type: bool
        /// </summary>
        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        /// <summary>
        /// if the message is generated by a webhook, this is the webhook's id
        /// </summary>
        [JsonProperty("webhook_id")]
        public string Webhook { get; set; }
    }


    /// <summary>
    /// Embeds Object
    /// https://discordapp.com/developers/docs/resources/channel#embed-object
    /// </summary>
    public class Embed
    {
        /// <summary>
        /// title of embed
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// type of embed (always "rich" for webhook embeds)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// description of embed
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// url of embed
        /// </summary>
        [JsonProperty("url")]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        /// <summary>
        /// timestamp of embed content
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// color code of the embed
        /// </summary>
        [JsonProperty("color")]
        public int Color { get; set; }

        public Footer Footer { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("video")]
        public Video Video { get; set; }

        [JsonProperty("provider")]
        public Provider Provider { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("fields")]
        public List<EmbedField> Fields { get; set; }
    }

    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("proxy_url")]
        public string ProxyUrl { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class EmbedProvider
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// Footer Struct
    /// https://discordapp.com/developers/docs/resources/channel#embed-footer-structure
    /// </summary>
    public class Footer
    {
        /// <summary>
        /// footer text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// url of footer icon (only supports http(s) and attachments)
        /// </summary>
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        /// a proxied url of footer icon
        /// </summary>
        [JsonProperty("proxy_icon_url")]
        public string IconProxyUrl { get; set; }
    }
}