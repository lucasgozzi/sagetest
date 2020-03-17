docker build -t front .
docker run -p 3001:3000 --rm front

docker build -t back .
docker run -p 5000:5000 back

http://localhost:3001/


 