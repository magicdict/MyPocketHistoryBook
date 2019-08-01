E:
cd E:\runmongo\bin
mkdir F:\HelloChinaApi\DataBase
mongod --port 27017 --storageEngine wiredTiger --dbpath F:\HelloChinaApi\DataBase --nojournal >> F:\HelloChinaApi\DataBase\Logger.log
