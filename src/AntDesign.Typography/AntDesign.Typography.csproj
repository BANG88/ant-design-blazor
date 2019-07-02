<Project Sdk="Microsoft.NET.Sdk.Razor">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <IsPackable>true</IsPackable>
    <LangVersion>7.3</LangVersion>
    <RazorLangVersion>3.0</RazorLangVersion>
    <AddRazorSupportForMvc>true</AddRazorSupportForMvc>
    <Description>Ant Design components for Blazor</Description>
    <PackageProjectUrl>https://bang88.github.io/ant-design-blazor/</PackageProjectUrl>
    <RepositoryUrl>https://github.com/bang88/ant-design-blazor</RepositoryUrl>
    <PackageTags>ant design bloazr components</PackageTags>
    <PackageRequireLicenseAcceptance>false</PackageRequireLicenseAcceptance>
    <RepositoryType>git</RepositoryType>
    <PackageLicenseUrl></PackageLicenseUrl>
    <Copyright>启邦</Copyright>
    <PackageReleaseNotes></PackageReleaseNotes>
    <PackageLicenseExpression>MIT</PackageLicenseExpression>
    <Authors>启邦</Authors>
    <PackageIconUrl>https://gw.alipayobjects.com/zos/rmsportal/KDpgvguMpGfqaHPjicRK.svg</PackageIconUrl>
		<PackageVersion>$(VersionSuffix)</PackageVersion>
  </PropertyGroup>

  <ItemGroup>
    <!-- .js/.css files will be referenced via <script>/<link> tags; other content files will just be included in the app's 'dist' directory without any tags referencing them -->
    <EmbeddedResource Include="content\**\*.js" LogicalName="blazor:js:%(RecursiveDir)%(Filename)%(Extension)" />
    <EmbeddedResource Include="content\**\*.css" LogicalName="blazor:css:%(RecursiveDir)%(Filename)%(Extension)" />
    <EmbeddedResource Include="content\**" Exclude="**\*.js;**\*.css" LogicalName="blazor:file:%(RecursiveDir)%(Filename)%(Extension)" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Components.Browser" Version="3.0.0-preview6.19307.2" />
  </ItemGroup>

  <ItemGroup>
    <Folder Include="content\" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\AntDesign.BaseComponent\AntDesign.BaseComponent.csproj" />
  </ItemGroup>

</Project>
