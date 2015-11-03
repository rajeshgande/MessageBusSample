This is a sample code for set of applications demonstrating communication over message bus using technoloiges rabbitmq and MT. It requires RabbitMQ to be installed. Please follow the instruction below to set up rabbitmq.



#RabbittMQ Setup
- Install Erlang. 
  - ([download link}(http://www.erlang.org/download.html))
- Install RabbitMQ.
  -  ([download link](https://www.rabbitmq.com/install-windows.html))
  -  additonal Installation instructions are ([here](https://www.rabbitmq.com/install-windows.html))
- Install Management API plug in
  - Open command prompt ( may be run as admin)
   - go to RabbitMQ install folder. 
   - Typically “C:\Program Files (x86)\RabbitMQ Server\rabbitmq_server-3.5.6\sbin”
   - execute the following command 
      - rabbitmq-plugins enable rabbitmq_management
   - Additional Info about the management plug in 
   - After adding the plug in, open the following url in a  browser 
     - http://localhost:15672/
     - Login using guest/guest.
