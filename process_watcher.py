import psutil
import time
import socket
import sys


process_name = 'InformationSystem_Lab_2.exe'


def log_event(message):
    """Записывает сообщение в лог без блокировки файла."""
    with open('logs.EventLogData', 'a', encoding='utf-8') as file:
        timestamp = time.strftime('%d.%m.%Y %H:%M:%S')
        file.write(f'{timestamp}\t{message}\n')

def watch_process():
	while True:
		if check_proces() == False:
			return
		time.sleep(1)

def check_proces():
	found = False
	for proc in psutil.process_iter(attrs=['pid', 'name']):
		if proc.info['name'] == process_name:
			found = True
			break
	if not found:
		log_event(f'ProgrammStop\t00000000-0000-0000-0000-000000000000\t{get_ip()}\tПользовательское приложение остановлено.')
		log_event(f'WatcherStop\t00000000-0000-0000-0000-000000000000\t{get_ip()}\tПрограмма мониторинга была остановлена.')
	return found

def get_ip():
	s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
	s.connect(("8.8.8.8", 80))
	ip = s.getsockname()[0]
	s.close()
	if ip == '127.0.0.1':
		ip == '255.255.255.255'
	return ip

if __name__ == '__main__':
	if len(sys.argv) == 1:
		log_event(f'ProgrammStart\t00000000-0000-0000-0000-000000000000\t{get_ip()}\tПользовательское приложение запущено.')
		log_event(f'WatcherStart\t00000000-0000-0000-0000-000000000000\t{get_ip()}\tПрограмма мониторинга была запущена.')
	else:
		log_event(f'WatcherRestarted\t00000000-0000-0000-0000-000000000000\t{get_ip()}\tПрограмма мониторинга была перезапущена.')
	
	watch_process()