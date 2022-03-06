if [ -z $FTP_IP ]; then
  FTP_DECL="-DFTP_IP=$FTP_IP";
fi

dotnet publish --sc -c Release -r linux-arm64 -o exlaunch-cmake/libs/
cmake -DCMAKE_TOOLCHAIN_FILE=cmake/toolchain.cmake $FTP_DECL -S exlaunch-cmake -B build
cmake --build build -t subsdk9_meta
