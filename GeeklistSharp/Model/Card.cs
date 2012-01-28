using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GeeklistSharp.Model
{
	/*
		author_id: "a271659310088dc1a09fe0af9ddf6dd2d1987ddb99d2ca23af50a7fae55256d9",
		created_at: "2011-09-14T04:46:30.384Z",
		happened_at: "2011-09-06T00:00:00.000Z",
		happened_at_type: "custom",
		headline: "I placed 23rd out of >180 at Nodeknockout 2011",
		is_active: true,
		permalink: "/chapel/i-placed-23rd-out-of-180-at-nodeknockout-2011",
		slug: "i-placed-23rd-out-of-180-at-nodeknockout-2011",
		tasks: [ ],
		updated_at: "2011-11-28T23:05:42.180Z",
		stats: {
			number_of_views: 55,
			views: 64,
			highfives: 3
		},
		short_code: {
			gklst_url: "http://gkl.st/XuQdJ",
			id: "32002d0dea77d1e55dcdb17b93456b789f0726b659e2d605bd6047db6c046865"
		},
		id: "32002d0dea77d1e55dcdb17b93456b7807b3c1b0695e177228f4fa12f227119b"     
	 */
	[DataContract]
	public class Card
	{
		[DataMember(Name = "author_id")]
		public string AuthorId { get; set; }

		[DataMember(Name="created_at")]
		public string CreatedAt { get; set; }

		[DataMember(Name = "happened_at")]
		public string HappenedAt { get; set; }

		[DataMember(Name = "happened_at_type")]
		public string HappenedAtType { get; set; }

		[DataMember(Name = "headline")]
		public string Headline { get; set; }

		[DataMember(Name = "is_active")]
		public bool IsActive { get; set; }

		[DataMember(Name = "permalink")]
		public string Permalink { get; set; }

		[DataMember(Name = "slug")]
		public string Slug { get; set; }

		[DataMember(Name = "tasks")]
        public List<string> Tasks { get; set; }

		[DataMember(Name = "updated_at")]
		public string UpdatedAt { get; set; }

		[DataMember(Name = "stats")]
		public Stats Stats { get; set; }

		[DataMember(Name = "short_code")]
		public ShortCode ShortCode { get; set; }

		[DataMember(Name = "trending_hist")]
        public List<string> TrendingHist { get; set; }

		[DataMember(Name = "trending_at")]
		public string TrendingAt { get; set; }

		[DataMember(Name = "is_trending")]
		public bool IsTrending { get; set; }

		[DataMember(Name = "skills")]
		public List<string> Skills { get; set; }

		[DataMember(Name = "id")]
		public string Id { get; set; }
	}
}
