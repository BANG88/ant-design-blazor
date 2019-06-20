cd test/AntDesign.Web && dotnet publish -c Release && cp -rf bin/Release/netstandard2.0/publish/AntDesign.Web/dist ../website/ && cp ../website/index.html ../website/dist/index.html && cp ../website/404.html ../website/dist/404.html;

echo "Publishing to gh-pages..."
cd ../website && gh-pages -d dist

