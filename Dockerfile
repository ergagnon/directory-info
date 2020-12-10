FROM ubuntu:bionic
ADD ./publish /app
ADD demo.sh /app
RUN chmod +x /app/demo.sh
WORKDIR "/app"
CMD ["./demo.sh"]