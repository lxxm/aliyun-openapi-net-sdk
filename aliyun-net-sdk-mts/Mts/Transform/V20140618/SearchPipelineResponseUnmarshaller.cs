/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
using Aliyun.Acs.Core.Transform;
using Aliyun.Acs.Mts.Model.V20140618;
using System;
using System.Collections.Generic;

namespace Aliyun.Acs.Mts.Transform.V20140618
{
    public class SearchPipelineResponseUnmarshaller
    {
        public static SearchPipelineResponse Unmarshall(UnmarshallerContext context)
        {
			SearchPipelineResponse searchPipelineResponse = new SearchPipelineResponse();

			searchPipelineResponse.HttpResponse = context.HttpResponse;
			searchPipelineResponse.RequestId = context.StringValue("SearchPipeline.RequestId");
			searchPipelineResponse.TotalCount = context.LongValue("SearchPipeline.TotalCount");
			searchPipelineResponse.PageNumber = context.LongValue("SearchPipeline.PageNumber");
			searchPipelineResponse.PageSize = context.LongValue("SearchPipeline.PageSize");

			List<SearchPipelineResponse.Pipeline> pipelineList = new List<SearchPipelineResponse.Pipeline>();
			for (int i = 0; i < context.Length("SearchPipeline.PipelineList.Length"); i++) {
				SearchPipelineResponse.Pipeline pipeline = new SearchPipelineResponse.Pipeline();
				pipeline.Id = context.StringValue("SearchPipeline.PipelineList["+ i +"].Id");
				pipeline.Name = context.StringValue("SearchPipeline.PipelineList["+ i +"].Name");
				pipeline.State = context.StringValue("SearchPipeline.PipelineList["+ i +"].State");
				pipeline.Speed = context.StringValue("SearchPipeline.PipelineList["+ i +"].Speed");
				pipeline.Role = context.StringValue("SearchPipeline.PipelineList["+ i +"].Role");

				SearchPipelineResponse.Pipeline.NotifyConfig_ notifyConfig = new SearchPipelineResponse.Pipeline.NotifyConfig_();
				notifyConfig.Topic = context.StringValue("SearchPipeline.PipelineList["+ i +"].NotifyConfig.Topic");
				pipeline.NotifyConfig = notifyConfig;

				pipelineList.Add(pipeline);
			}
			searchPipelineResponse.PipelineList = pipelineList;
        
			return searchPipelineResponse;
        }
    }
}