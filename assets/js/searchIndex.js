
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"NpmUpdateSettings",
            content:"NpmUpdateSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Update/NpmUpdateSettings',
            title:"NpmUpdateSettings",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"NpmInstallSettings",
            content:"NpmInstallSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Install/NpmInstallSettings',
            title:"NpmInstallSettings",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"NpmAddUserSettings",
            content:"NpmAddUserSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.AddUser/NpmAddUserSettings',
            title:"NpmAddUserSettings",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"NpmAddUserSettingsExtensions",
            content:"NpmAddUserSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.AddUser/NpmAddUserSettingsExtensions',
            title:"NpmAddUserSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"NpmSetTool",
            content:"NpmSetTool",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Set/NpmSetTool',
            title:"NpmSetTool",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"NpmRunScriptSettings",
            content:"NpmRunScriptSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.RunScript/NpmRunScriptSettings',
            title:"NpmRunScriptSettings",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"NpmViewVersionSettings",
            content:"NpmViewVersionSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.ViewVersion/NpmViewVersionSettings',
            title:"NpmViewVersionSettings",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"NpmCiAliases",
            content:"NpmCiAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmCiAliases',
            title:"NpmCiAliases",
            description:""
        }
    );
    a(
        {
            id:8,
            title:"NpmPackSettingsExtensions",
            content:"NpmPackSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Pack/NpmPackSettingsExtensions',
            title:"NpmPackSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:9,
            title:"NpmRebuildAliases",
            content:"NpmRebuildAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmRebuildAliases',
            title:"NpmRebuildAliases",
            description:""
        }
    );
    a(
        {
            id:10,
            title:"NpmLogLevel",
            content:"NpmLogLevel",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmLogLevel',
            title:"NpmLogLevel",
            description:""
        }
    );
    a(
        {
            id:11,
            title:"NpmPruneSettingsExtensions",
            content:"NpmPruneSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Prune/NpmPruneSettingsExtensions',
            title:"NpmPruneSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:12,
            title:"NpmViewVersionAliases",
            content:"NpmViewVersionAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmViewVersionAliases',
            title:"NpmViewVersionAliases",
            description:""
        }
    );
    a(
        {
            id:13,
            title:"NpmTool",
            content:"NpmTool",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmTool_1',
            title:"NpmTool<TSettings>",
            description:""
        }
    );
    a(
        {
            id:14,
            title:"NpmPublishAliases",
            content:"NpmPublishAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmPublishAliases',
            title:"NpmPublishAliases",
            description:""
        }
    );
    a(
        {
            id:15,
            title:"NpmPublishSettingsExtensions",
            content:"NpmPublishSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Publish/NpmPublishSettingsExtensions',
            title:"NpmPublishSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:16,
            title:"NpmRebuildSettings",
            content:"NpmRebuildSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Rebuild/NpmRebuildSettings',
            title:"NpmRebuildSettings",
            description:""
        }
    );
    a(
        {
            id:17,
            title:"NpmBumpVersionAliases",
            content:"NpmBumpVersionAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmBumpVersionAliases',
            title:"NpmBumpVersionAliases",
            description:""
        }
    );
    a(
        {
            id:18,
            title:"NpmVersionSettings",
            content:"NpmVersionSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Version/NpmVersionSettings',
            title:"NpmVersionSettings",
            description:""
        }
    );
    a(
        {
            id:19,
            title:"NpmPublishSettings",
            content:"NpmPublishSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Publish/NpmPublishSettings',
            title:"NpmPublishSettings",
            description:""
        }
    );
    a(
        {
            id:20,
            title:"NpmBumpVersionSettings",
            content:"NpmBumpVersionSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.BumpVersion/NpmBumpVersionSettings',
            title:"NpmBumpVersionSettings",
            description:""
        }
    );
    a(
        {
            id:21,
            title:"NpmAddUserAliases",
            content:"NpmAddUserAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmAddUserAliases',
            title:"NpmAddUserAliases",
            description:""
        }
    );
    a(
        {
            id:22,
            title:"NpmRunScriptAliases",
            content:"NpmRunScriptAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmRunScriptAliases',
            title:"NpmRunScriptAliases",
            description:""
        }
    );
    a(
        {
            id:23,
            title:"NpmSettingsExtensions",
            content:"NpmSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmSettingsExtensions',
            title:"NpmSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:24,
            title:"NpmInstallSettingsExtensions",
            content:"NpmInstallSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Install/NpmInstallSettingsExtensions',
            title:"NpmInstallSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:25,
            title:"NpmRunScriptSettingsExtensions",
            content:"NpmRunScriptSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.RunScript/NpmRunScriptSettingsExtensions',
            title:"NpmRunScriptSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:26,
            title:"NpmPruneRunner",
            content:"NpmPruneRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Prune/NpmPruneRunner',
            title:"NpmPruneRunner",
            description:""
        }
    );
    a(
        {
            id:27,
            title:"NpmViewVersionTool",
            content:"NpmViewVersionTool",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.ViewVersion/NpmViewVersionTool',
            title:"NpmViewVersionTool",
            description:""
        }
    );
    a(
        {
            id:28,
            title:"NpmViewVersionSettingsExtensions",
            content:"NpmViewVersionSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.ViewVersion/NpmViewVersionSettingsExtensions',
            title:"NpmViewVersionSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:29,
            title:"NpmRebuildSettingsExtensions",
            content:"NpmRebuildSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Rebuild/NpmRebuildSettingsExtensions',
            title:"NpmRebuildSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:30,
            title:"NpmPackAliases",
            content:"NpmPackAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmPackAliases',
            title:"NpmPackAliases",
            description:""
        }
    );
    a(
        {
            id:31,
            title:"AuthType",
            content:"AuthType",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.AddUser/AuthType',
            title:"AuthType",
            description:""
        }
    );
    a(
        {
            id:32,
            title:"NpmCiTool",
            content:"NpmCiTool",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Ci/NpmCiTool',
            title:"NpmCiTool",
            description:""
        }
    );
    a(
        {
            id:33,
            title:"NpmBumpVersionTool",
            content:"NpmBumpVersionTool",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.BumpVersion/NpmBumpVersionTool',
            title:"NpmBumpVersionTool",
            description:""
        }
    );
    a(
        {
            id:34,
            title:"NpmBumpVersionSettingsExtensions",
            content:"NpmBumpVersionSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.BumpVersion/NpmBumpVersionSettingsExtensions',
            title:"NpmBumpVersionSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:35,
            title:"NpmUpdateTool",
            content:"NpmUpdateTool",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Update/NpmUpdateTool',
            title:"NpmUpdateTool",
            description:""
        }
    );
    a(
        {
            id:36,
            title:"NpmSetSettingsExtensions",
            content:"NpmSetSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Set/NpmSetSettingsExtensions',
            title:"NpmSetSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:37,
            title:"NpmSetAliases",
            content:"NpmSetAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmSetAliases',
            title:"NpmSetAliases",
            description:""
        }
    );
    a(
        {
            id:38,
            title:"NpmPublisher",
            content:"NpmPublisher",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Publish/NpmPublisher',
            title:"NpmPublisher",
            description:""
        }
    );
    a(
        {
            id:39,
            title:"NpmPruneAliases",
            content:"NpmPruneAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmPruneAliases',
            title:"NpmPruneAliases",
            description:""
        }
    );
    a(
        {
            id:40,
            title:"NpmUpdateSettingsExtensions",
            content:"NpmUpdateSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Update/NpmUpdateSettingsExtensions',
            title:"NpmUpdateSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:41,
            title:"NpmPacker",
            content:"NpmPacker",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Pack/NpmPacker',
            title:"NpmPacker",
            description:""
        }
    );
    a(
        {
            id:42,
            title:"NpmInstallAliases",
            content:"NpmInstallAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmInstallAliases',
            title:"NpmInstallAliases",
            description:""
        }
    );
    a(
        {
            id:43,
            title:"NpmInstaller",
            content:"NpmInstaller",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Install/NpmInstaller',
            title:"NpmInstaller",
            description:""
        }
    );
    a(
        {
            id:44,
            title:"NpmVersionAliases",
            content:"NpmVersionAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmVersionAliases',
            title:"NpmVersionAliases",
            description:""
        }
    );
    a(
        {
            id:45,
            title:"NpmSettings",
            content:"NpmSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmSettings',
            title:"NpmSettings",
            description:""
        }
    );
    a(
        {
            id:46,
            title:"NpmRebuilder",
            content:"NpmRebuilder",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Rebuild/NpmRebuilder',
            title:"NpmRebuilder",
            description:""
        }
    );
    a(
        {
            id:47,
            title:"NpmCiSettings",
            content:"NpmCiSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Ci/NpmCiSettings',
            title:"NpmCiSettings",
            description:""
        }
    );
    a(
        {
            id:48,
            title:"NpmPruneSettings",
            content:"NpmPruneSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Prune/NpmPruneSettings',
            title:"NpmPruneSettings",
            description:""
        }
    );
    a(
        {
            id:49,
            title:"NpmPublishAccess",
            content:"NpmPublishAccess",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Publish/NpmPublishAccess',
            title:"NpmPublishAccess",
            description:""
        }
    );
    a(
        {
            id:50,
            title:"NpmPackSettings",
            content:"NpmPackSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Pack/NpmPackSettings',
            title:"NpmPackSettings",
            description:""
        }
    );
    a(
        {
            id:51,
            title:"NpmSetSettings",
            content:"NpmSetSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Set/NpmSetSettings',
            title:"NpmSetSettings",
            description:""
        }
    );
    a(
        {
            id:52,
            title:"NpmScriptRunner",
            content:"NpmScriptRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.RunScript/NpmScriptRunner',
            title:"NpmScriptRunner",
            description:""
        }
    );
    a(
        {
            id:53,
            title:"NpmUpdateAliases",
            content:"NpmUpdateAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm/NpmUpdateAliases',
            title:"NpmUpdateAliases",
            description:""
        }
    );
    a(
        {
            id:54,
            title:"NpmAddUser",
            content:"NpmAddUser",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.AddUser/NpmAddUser',
            title:"NpmAddUser",
            description:""
        }
    );
    a(
        {
            id:55,
            title:"NpmVersionTool",
            content:"NpmVersionTool",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Version/NpmVersionTool',
            title:"NpmVersionTool",
            description:""
        }
    );
    a(
        {
            id:56,
            title:"NpmCiSettingsExtensions",
            content:"NpmCiSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Npm/api/Cake.Npm.Ci/NpmCiSettingsExtensions',
            title:"NpmCiSettingsExtensions",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
