set -e

if [ "$version" == "" ]; then
    echo "version needed."
    exit 1
fi
if [ "$key" == "" ]; then
    echo "key needed."
    exit 1
fi

release="./bin/Release/"

for d in ./src/*/; do (cd "$d" && rm -rf "$release" && dotnet pack --version-suffix "$version" -c Release && find "$release" -iname "*.$version.nupkg" -exec dotnet nuget push {} -k "$key" -s https://api.nuget.org/v3/index.json \; && rm -rf "$release" "./obj/Release/"); done
