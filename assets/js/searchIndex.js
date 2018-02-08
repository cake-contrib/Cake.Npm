
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"NpmScriptRunner",
        content:"NpmScriptRunner",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"NpmInstallSettingsExtensions",
        content:"NpmInstallSettingsExtensions",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"NpmInstallAliases",
        content:"NpmInstallAliases",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"NpmPublishSettingsExtensions",
        content:"NpmPublishSettingsExtensions",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"NpmLogLevel",
        content:"NpmLogLevel",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"NpmSettings",
        content:"NpmSettings",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"NpmPublisher",
        content:"NpmPublisher",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"NpmSettingsExtensions",
        content:"NpmSettingsExtensions",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"NpmRebuildSettings",
        content:"NpmRebuildSettings",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"NpmPublishSettings",
        content:"NpmPublishSettings",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"NpmInstallSettings",
        content:"NpmInstallSettings",
        description:'',
        tags:''
    });

    a({
        id:11,
        title:"NpmRebuilSettingsExtensions",
        content:"NpmRebuilSettingsExtensions",
        description:'',
        tags:''
    });

    a({
        id:12,
        title:"NpmRebuilder",
        content:"NpmRebuilder",
        description:'',
        tags:''
    });

    a({
        id:13,
        title:"NpmPackSettingsExtensions",
        content:"NpmPackSettingsExtensions",
        description:'',
        tags:''
    });

    a({
        id:14,
        title:"NpmPublishAccess",
        content:"NpmPublishAccess",
        description:'',
        tags:''
    });

    a({
        id:15,
        title:"NpmRunScriptSettingsExtensions",
        content:"NpmRunScriptSettingsExtensions",
        description:'',
        tags:''
    });

    a({
        id:16,
        title:"NpmPackAliases",
        content:"NpmPackAliases",
        description:'',
        tags:''
    });

    a({
        id:17,
        title:"NpmRunScriptAliases",
        content:"NpmRunScriptAliases",
        description:'',
        tags:''
    });

    a({
        id:18,
        title:"NpmTool",
        content:"NpmTool",
        description:'',
        tags:''
    });

    a({
        id:19,
        title:"NpmPublishAliases",
        content:"NpmPublishAliases",
        description:'',
        tags:''
    });

    a({
        id:20,
        title:"NpmRebuildAliases",
        content:"NpmRebuildAliases",
        description:'',
        tags:''
    });

    a({
        id:21,
        title:"NpmPackSettings",
        content:"NpmPackSettings",
        description:'',
        tags:''
    });

    a({
        id:22,
        title:"NpmInstaller",
        content:"NpmInstaller",
        description:'',
        tags:''
    });

    a({
        id:23,
        title:"NpmRunScriptSettings",
        content:"NpmRunScriptSettings",
        description:'',
        tags:''
    });

    a({
        id:24,
        title:"NpmPacker",
        content:"NpmPacker",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.RunScript/NpmScriptRunner',
        title:"NpmScriptRunner",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Install/NpmInstallSettingsExtensions',
        title:"NpmInstallSettingsExtensions",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm/NpmInstallAliases',
        title:"NpmInstallAliases",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Publish/NpmPublishSettingsExtensions',
        title:"NpmPublishSettingsExtensions",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm/NpmLogLevel',
        title:"NpmLogLevel",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm/NpmSettings',
        title:"NpmSettings",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Publish/NpmPublisher',
        title:"NpmPublisher",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm/NpmSettingsExtensions',
        title:"NpmSettingsExtensions",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Rebuild/NpmRebuildSettings',
        title:"NpmRebuildSettings",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Publish/NpmPublishSettings',
        title:"NpmPublishSettings",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Install/NpmInstallSettings',
        title:"NpmInstallSettings",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Rebuild/NpmRebuilSettingsExtensions',
        title:"NpmRebuilSettingsExtensions",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Rebuild/NpmRebuilder',
        title:"NpmRebuilder",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Pack/NpmPackSettingsExtensions',
        title:"NpmPackSettingsExtensions",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Publish/NpmPublishAccess',
        title:"NpmPublishAccess",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.RunScript/NpmRunScriptSettingsExtensions',
        title:"NpmRunScriptSettingsExtensions",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm/NpmPackAliases',
        title:"NpmPackAliases",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm/NpmRunScriptAliases',
        title:"NpmRunScriptAliases",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm/NpmTool_1',
        title:"NpmTool<TSettings>",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm/NpmPublishAliases',
        title:"NpmPublishAliases",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm/NpmRebuildAliases',
        title:"NpmRebuildAliases",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Pack/NpmPackSettings',
        title:"NpmPackSettings",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Install/NpmInstaller',
        title:"NpmInstaller",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.RunScript/NpmRunScriptSettings',
        title:"NpmRunScriptSettings",
        description:""
    });

    y({
        url:'/Cake.Npm/api/Cake.Npm.Pack/NpmPacker',
        title:"NpmPacker",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
