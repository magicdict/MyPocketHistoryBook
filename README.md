# 上海中和软件 Angular培训用综合例子

## 技术栈

- 数据库：MongoDB 4.1.1
- NetCore：3.0.0 - Preview7
- Angular 9.0 - Next（测试版）

## 目录构成

- 教程：培训用单个主题教程
- 小程序：（准备中，小程序的源代码）
- 资料：sqlite数据库，图片资料
- Serve：.NetCore代码
- UI：Angular代码
- nginx.conf:反向代理服务器配置
- release.bat:编译Netcore和Angular，并且复制编译结果到指定文件夹

## 部署环境

阿里云CentOS7

## 部署方法

- MongoDB的确认：
  - systemctl start mongod.service
  - /etc/mongod.conf (配置文件：在资料的MongoDB文件夹中保存)
- Nginx
  - /usr/local/nginx/conf
  - ./nginx 启动 (/usr/local/nginx/sbin)
  - ./nginx -s reload (/usr/local/nginx/sbin)
- NetCore
  - /etc/systemd/system/  将启动文件 HelloChinaApi.service 放在这个目录下面
  
## 注意点

Linux编码问题，如果web api中出现中文，一定要进行转码：
  